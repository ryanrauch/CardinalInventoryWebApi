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
}
