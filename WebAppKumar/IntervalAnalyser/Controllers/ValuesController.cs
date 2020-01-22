using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using IntervalAnalyser.DbClasses;
using IntervalAnalyser.Interfaces;

namespace IntervalAnalyser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IntervalContext _IntervalContext;
        private IDataReporting _DataReporting;

        public ValuesController(IntervalContext intervalContext, IDataReporting dataReporting)
        {
            _IntervalContext = intervalContext;
            _DataReporting = dataReporting;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<IntervalData>> Get()
        {
            List<string> returnVal= new List<string>();
            var returnedList = _DataReporting.ProcessIntervalData(_IntervalContext.IntervalData);
            return returnedList;
        }
    }
}
