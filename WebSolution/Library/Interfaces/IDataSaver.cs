using System.Collections.Generic;

namespace Library.Interfaces
{
    public interface IDataSaver
    {
        void ConvertToExcel(List<IntervalData> intervalDataList, string folderPath);

    }
}
