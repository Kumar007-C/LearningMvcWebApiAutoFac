using Library;
using Library.Implementations;
using Library.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace WebSolution.Controllers
{
    public class HomeController : Controller
    {
        private IDataSaver _DataSaver;
        public HomeController(IDataSaver dataSaver)
        {
            _DataSaver = dataSaver;
        }


        public ActionResult Index()
        {
            var result = new APIConsumer().ConsumeAPI();
            TempData["Result"] = result.Result;
            return View();
        }

        public ActionResult Download()
        {
            var folderPath = ConfigurationManager.AppSettings["FolderPath"];
            _DataSaver.ConvertToExcel((List<IntervalData>)TempData["Result"], folderPath);
            return View("Index");
        }

    }
}