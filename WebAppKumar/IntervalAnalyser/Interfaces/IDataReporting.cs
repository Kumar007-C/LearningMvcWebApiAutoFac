using IntervalAnalyser.DbClasses;
using System.Collections.Generic;

namespace IntervalAnalyser.Interfaces
{
    public interface IDataReporting
    {
        List<IntervalData> ProcessIntervalData(IEnumerable<IntervalData> intervalRecords);
    }
}
