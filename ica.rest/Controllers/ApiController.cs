using System;
using Izone.DB;
using Microsoft.AspNetCore.Mvc;

namespace ica.rest.Controllers
{
    [Route("/")]
    public class ApiController : Controller
    {
        readonly ITimeEntryRepository _timeEntryRepository;
        public ApiController(ITimeEntryRepository timeEntryRepository)
        {
            _timeEntryRepository = timeEntryRepository;
        }

        [HttpGet]
        public string Index()
        {
            return "IZONE CORE API";
        }

        [HttpGet]
        [Route("/status")]
        public string Status()
        {
            var dbConnectionStatus = "DOWN";

            try
            {
                var hours = _timeEntryRepository.TotalHours();
                Console.WriteLine(string.Format("GET /status - DB OK. Total time entries: {0} h", hours));

                dbConnectionStatus = "OK";
            }
            catch (Exception exception)
            {
                Console.WriteLine("GET /status - database connection failed.");
                Console.WriteLine(exception.Message);
            }

            return string.Format("Database connection: {0}", dbConnectionStatus);
        }
    }
}
