using System;
using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects
{
    public class SlotObject
    {
        public string OrderID { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public bool InUse { get; set; }
        public bool ActiveSlot { get; set; }
        public EnumSlotType Type { get; set; }
        public bool WaitingForExecuting { get; set; }
        public DateTime LockTimeStamp { get; set; }
        public List<string> OrderIDs { get; set; }
    }
}