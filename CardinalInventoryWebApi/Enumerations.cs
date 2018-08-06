using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardinalInventoryWebApi
{
    public enum InventoryAction
    {
        UserViewedAuto = 0,
        UserViewedManual = 1,
        ReceivedManual = 2,
        ReceivedAuto = 3,
        RemovedDuringInventory = 4
    }

    public enum EventStationHardware
    {
        RPIwithPN532 = 0
    }

    public enum EventStationControlType
    {
        EntryGate = 0,
        ExitGate = 1,
        ValidationOnly = 2
    }

    public enum TicketPhysicalType
    {
        RFIDWristBand = 0
    }

    public enum EventStationProcessResult
    {
        Successful = 0,
        Duplicate = 1,
        UnknownUniqueIdentifier = 2,
        UnknownEventStationId = 3,
        UnknownEventStationAdmissionType = 4,
        CompletedEventId = 5,
        TicketDisabled = 6,
        TicketAdmissionTypeIssue = 7,
        Error = 8
    }
}
