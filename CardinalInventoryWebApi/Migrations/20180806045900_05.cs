using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CardinalInventoryWebApi.Migrations
{
    public partial class _05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventCustomers",
                columns: table => new
                {
                    EventCustomerId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCustomers", x => x.EventCustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "EventStations",
                columns: table => new
                {
                    EventStationId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Hardware = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStations", x => x.EventStationId);
                });

            migrationBuilder.CreateTable(
                name: "EventTicketHistories",
                columns: table => new
                {
                    EventTicketHistoryId = table.Column<Guid>(nullable: false),
                    EventTicketId = table.Column<Guid>(nullable: false),
                    ColumnChanged = table.Column<string>(nullable: true),
                    OldValue = table.Column<string>(nullable: true),
                    NewValue = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTicketHistories", x => x.EventTicketHistoryId);
                });

            migrationBuilder.CreateTable(
                name: "EventTicketAdmissionTypes",
                columns: table => new
                {
                    EventTicketAdmissionTypeId = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTicketAdmissionTypes", x => x.EventTicketAdmissionTypeId);
                    table.ForeignKey(
                        name: "FK_EventTicketAdmissionTypes_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventStationAssignments",
                columns: table => new
                {
                    EventId = table.Column<Guid>(nullable: false),
                    EventStationId = table.Column<Guid>(nullable: false),
                    EventTicketAdmissionTypeId = table.Column<Guid>(nullable: false),
                    ControlType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStationAssignments", x => new { x.EventId, x.EventStationId });
                    table.ForeignKey(
                        name: "FK_EventStationAssignments_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventStationAssignments_EventStations_EventStationId",
                        column: x => x.EventStationId,
                        principalTable: "EventStations",
                        principalColumn: "EventStationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventStationAssignments_EventTicketAdmissionTypes_EventTicketAdmissionTypeId",
                        column: x => x.EventTicketAdmissionTypeId,
                        principalTable: "EventTicketAdmissionTypes",
                        principalColumn: "EventTicketAdmissionTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventTickets",
                columns: table => new
                {
                    EventTicketId = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: false),
                    EventTicketAdmissionTypeId = table.Column<Guid>(nullable: false),
                    UniqueIdentifier = table.Column<string>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false, defaultValue: true),
                    EventCustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTickets", x => x.EventTicketId);
                    table.ForeignKey(
                        name: "FK_EventTickets_EventCustomers_EventCustomerId",
                        column: x => x.EventCustomerId,
                        principalTable: "EventCustomers",
                        principalColumn: "EventCustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTickets_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTickets_EventTicketAdmissionTypes_EventTicketAdmissionTypeId",
                        column: x => x.EventTicketAdmissionTypeId,
                        principalTable: "EventTicketAdmissionTypes",
                        principalColumn: "EventTicketAdmissionTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventTicketStatuses",
                columns: table => new
                {
                    EventTicketId = table.Column<Guid>(nullable: false),
                    EventTicketAdmissionTypeId = table.Column<Guid>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTicketStatuses", x => new { x.EventTicketId, x.EventTicketAdmissionTypeId });
                    table.ForeignKey(
                        name: "FK_EventTicketStatuses_EventTicketAdmissionTypes_EventTicketAdmissionTypeId",
                        column: x => x.EventTicketAdmissionTypeId,
                        principalTable: "EventTicketAdmissionTypes",
                        principalColumn: "EventTicketAdmissionTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTicketStatuses_EventTickets_EventTicketId",
                        column: x => x.EventTicketId,
                        principalTable: "EventTickets",
                        principalColumn: "EventTicketId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventTicketStatusHistories",
                columns: table => new
                {
                    EventTicketStatusHistoryId = table.Column<Guid>(nullable: false),
                    EventTicketId = table.Column<Guid>(nullable: false),
                    EventTicketAdmissionTypeId = table.Column<Guid>(nullable: false),
                    EventStationId = table.Column<Guid>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    EventStationControlType = table.Column<int>(nullable: false),
                    EventStationProcessResult = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTicketStatusHistories", x => x.EventTicketStatusHistoryId);
                    table.ForeignKey(
                        name: "FK_EventTicketStatusHistories_EventStations_EventStationId",
                        column: x => x.EventStationId,
                        principalTable: "EventStations",
                        principalColumn: "EventStationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTicketStatusHistories_EventTicketAdmissionTypes_EventTicketAdmissionTypeId",
                        column: x => x.EventTicketAdmissionTypeId,
                        principalTable: "EventTicketAdmissionTypes",
                        principalColumn: "EventTicketAdmissionTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTicketStatusHistories_EventTickets_EventTicketId",
                        column: x => x.EventTicketId,
                        principalTable: "EventTickets",
                        principalColumn: "EventTicketId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventStationAssignments_EventStationId",
                table: "EventStationAssignments",
                column: "EventStationId");

            migrationBuilder.CreateIndex(
                name: "IX_EventStationAssignments_EventTicketAdmissionTypeId",
                table: "EventStationAssignments",
                column: "EventTicketAdmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTicketAdmissionTypes_EventId",
                table: "EventTicketAdmissionTypes",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTickets_EventCustomerId",
                table: "EventTickets",
                column: "EventCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTickets_EventId",
                table: "EventTickets",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTickets_EventTicketAdmissionTypeId",
                table: "EventTickets",
                column: "EventTicketAdmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTicketStatuses_EventTicketAdmissionTypeId",
                table: "EventTicketStatuses",
                column: "EventTicketAdmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTicketStatusHistories_EventStationId",
                table: "EventTicketStatusHistories",
                column: "EventStationId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTicketStatusHistories_EventTicketAdmissionTypeId",
                table: "EventTicketStatusHistories",
                column: "EventTicketAdmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTicketStatusHistories_EventTicketId",
                table: "EventTicketStatusHistories",
                column: "EventTicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventStationAssignments");

            migrationBuilder.DropTable(
                name: "EventTicketHistories");

            migrationBuilder.DropTable(
                name: "EventTicketStatuses");

            migrationBuilder.DropTable(
                name: "EventTicketStatusHistories");

            migrationBuilder.DropTable(
                name: "EventStations");

            migrationBuilder.DropTable(
                name: "EventTickets");

            migrationBuilder.DropTable(
                name: "EventCustomers");

            migrationBuilder.DropTable(
                name: "EventTicketAdmissionTypes");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
