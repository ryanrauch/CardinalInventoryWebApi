﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardinalInventoryWebApi.Data;
using CardinalInventoryWebApi.Data.EventManagement;
using CardinalInventoryWebApi.Data.EventManagement.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardinalInventoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTicketScanController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventTicketScanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/EventTicketScan
        [HttpPost]
        public async Task<IActionResult> PostEventTicketScan([FromBody] EventTicketScanContract etsc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check that a valid ticket exists
            var ticket = _context.EventTickets.FirstOrDefault(e => e.UniqueIdentifier.Equals(etsc.TicketUID));
            if(ticket == null)
            {
                return Ok(EventStationProcessResult.UnknownUniqueIdentifier);
            }
            // Check that the ticket has not been disabled
            if(!ticket.Enabled)
            {
                return Ok(EventStationProcessResult.TicketDisabled);
            }

            // Check that it is not an old ticket from a previous event still in database
            var currentEvent = _context.Events.FirstOrDefault(e => e.EventId.Equals(ticket.EventId)
                                                                && e.Completed.Equals(false));
            if(currentEvent == null)
            {
                return Ok(EventStationProcessResult.CompletedEventId);
            }

            // Check that a station exists for the ticket's event
            var station = _context.EventStations.FirstOrDefault(e => e.EventStationId.Equals(etsc.EventStationId));
            if (station == null)
            {
                return Ok(EventStationProcessResult.UnknownEventStationId);
            }

            // Check that the station assignment exists for the ticket's event
            var stationAssignment = _context.EventStationAssignments.FirstOrDefault(e => e.EventStationId.Equals(etsc.EventStationId)
                                                                                      && e.EventId.Equals(ticket.EventId));
            if(stationAssignment == null)
            {
                return Ok(EventStationProcessResult.UnknownEventStationId);
            }

            // Check that the station has a valid EventTicketAdmissionType
            var stationAdmissionType = _context.EventTicketAdmissionTypes.FirstOrDefault(e => e.EventTicketAdmissionTypeId.Equals(stationAssignment.EventTicketAdmissionTypeId));
            if(stationAdmissionType == null)
            {
                await CreateEventTicketStatusHistory(ticket.EventTicketId,
                                                     stationAdmissionType.EventTicketAdmissionTypeId,
                                                     stationAssignment.EventStationId,
                                                     stationAssignment.ControlType,
                                                     EventStationProcessResult.UnknownEventStationAdmissionType);
                return Ok(EventStationProcessResult.UnknownEventStationAdmissionType);
            }

            var insideRecords = await _context.EventTicketStatuses.Where(e => e.EventTicketId.Equals(ticket.EventTicketId)).ToListAsync();
            if(insideRecords.Count == 0)
            {
                if (stationAssignment.ControlType == EventStationControlType.EntryGate)
                {
                    var entered = new EventTicketStatus()
                    {
                        EventTicketId = ticket.EventTicketId,
                        EventTicketAdmissionTypeId = stationAssignment.EventTicketAdmissionTypeId,
                        TimeStamp = DateTime.UtcNow
                    };
                    await _context.EventTicketStatuses.AddAsync(entered);
                }
                else if (stationAssignment.ControlType == EventStationControlType.ExitGate)
                {
                    //var eventst
                }
                await _context.SaveChangesAsync();
                return Ok(EventStationProcessResult.Successful); 
            }
            foreach(var ins in insideRecords)
            {
                //if(ins.)
            }
            //_context.EventTicketStatuses.Add(eventTicketStatus);
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (EventTicketStatusExists(eventTicketStatus.EventTicketId))
            //    {
            //        return new StatusCodeResult(StatusCodes.Status409Conflict);
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtAction("GetEventTicketStatus", new { id = eventTicketStatus.EventTicketId }, eventTicketStatus);
            return Ok();
        }

        private async Task CreateEventTicketStatusHistory(
            Guid eventTicketId,
            Guid eventTicketAdmissionTypeId,
            Guid eventStationId,
            EventStationControlType eventStationControlType,
            EventStationProcessResult eventStationProcessResult)
        {
            var history = new EventTicketStatusHistory()
            {
                EventTicketStatusHistoryId = Guid.NewGuid(),
                EventTicketId = eventTicketId,
                EventTicketAdmissionTypeId = eventTicketAdmissionTypeId,
                EventStationId = eventStationId,
                EventStationControlType = eventStationControlType,
                EventStationProcessResult = eventStationProcessResult
            };
            await _context.EventTicketStatusHistories.AddAsync(history);
            await _context.SaveChangesAsync();
        }
    }
}