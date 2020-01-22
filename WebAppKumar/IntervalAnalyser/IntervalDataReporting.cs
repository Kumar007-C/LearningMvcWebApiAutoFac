using IntervalAnalyser.DbClasses;
using IntervalAnalyser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntervalAnalyser
{
    public class IntervalDataReporting: IDataReporting
    {

        /// <summary>
        /// Formats the result to group the interval data on hourly basis
        /// </summary>
        /// <param name="intervalRecords">The Enumerable list of Interval Data</param>
        /// <returns></returns>
        public List<IntervalData> ProcessIntervalData(IEnumerable<IntervalData> intervalRecords)
        {
            IEnumerable<IntervalData> returnVal = new List<IntervalData>();
           
            returnVal = intervalRecords.GroupBy
                (
                interval => new
                {
                    interval.Date,
                    interval.TimeSlot.Hours
                 }
                )
                .Select
                (interval => new IntervalData
                {
                    Date = interval.Key.Date,
                    TimeSlot = new TimeSpan( interval.Key.Hours,0,0) ,
                    SlotVal = interval.Sum(s => s.SlotVal)
                }
                )
                ;

            return returnVal.ToList();

        }
    }
}
