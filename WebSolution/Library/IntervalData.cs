using System;

namespace Library
{
    public class IntervalData
    {
        public int ID { get; set; }
        public long DeliveryPoint { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeSlot { get; set; }
        public decimal SlotVal { get; set; }
    }
}
