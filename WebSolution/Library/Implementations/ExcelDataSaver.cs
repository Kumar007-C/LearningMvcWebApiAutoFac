using IronXL;
using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Library.Implementations
{
    public class ExcelDataSaver : IDataSaver
    {
        public void ConvertToExcel(List<IntervalData> intervalDataList, string folderPath)
        {
            var intervalDataWorkBook = WorkBook.Create(ExcelFileFormat.XLSX);
            var xlsSheet = intervalDataWorkBook.CreateWorkSheet("Sheet 1");

            xlsSheet["A1"].Value = "Date";
            xlsSheet["B1"].Value = "TimeSlot";
            xlsSheet["C1"].Value = "SlotVal";

            var counter = 2;
            string timeSpanRepresentation;
            string dateValue;
            foreach (var intervalItem in intervalDataList)
            {
                timeSpanRepresentation = $"{intervalItem.TimeSlot.ToString(@"hh")} - {intervalItem.TimeSlot.ToString(@"mm")}";
                dateValue = intervalItem.Date.ToString("dd MMM yyyy");
                xlsSheet[$"A{counter}"].Value = dateValue;
                xlsSheet[$"B{counter}"].StringValue = timeSpanRepresentation;
                xlsSheet[$"C{counter}"].Value = intervalItem.SlotVal.ToString("0.00");
                counter++;
            }

            Directory.CreateDirectory(folderPath);
            var fileName = $@"NewExcelFile{DateTime.Now.ToString(@"hh\:mm\:ss").Replace(":", "-")}.xlsx";
            intervalDataWorkBook.SaveAs(Path.Combine(folderPath,fileName));

        }

       
    }
}