﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CardinalInventoryWebApi.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace CardinalInventoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public TokenController(
            SignInManager<ApplicationUser> signInManager,
            ILogger<TokenController> logger,
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _configuration = configuration;
            _userManager = userManager;
        }

        //POST: api/Token
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromForm]string username, [FromForm]string password, [FromForm]bool persistent)
        {
            bool foundemail = true;
            var user = await _userManager.FindByEmailAsync(username);
            if (user == null)
            {
                foundemail = false;
                user = await _userManager.FindByNameAsync(username);
                if (user == null)
                {
                    return BadRequest();
                }
            }
            var result = await _signInManager.PasswordSignInAsync(user, password, persistent, false);
            if (result == Microsoft.AspNetCore.Identity.SignInResult.Success)
            {
                _logger.LogInformation(user.UserName + " logged in.");
                string token = await GenerateToken(username, foundemail);
                return new ObjectResult(token);
            }
            return BadRequest();
        }

        private async Task<string> GenerateToken(string username, bool foundemail)
        {
            ApplicationUser appUser;
            if (foundemail)
            {
                appUser = await _userManager.FindByEmailAsync(username);
            }
            else
            {
                appUser = await _userManager.FindByNameAsync(username);
            }
            var claims = new Claim[]
            {
                //new Claim(ClaimTypes.Name, username),
                //new Claim(ClaimTypes.NameIdentifier, appUser.Id),
                new Claim(JwtRegisteredClaimNames.Jti, appUser.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[Constants.JwtSecretKey])),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}