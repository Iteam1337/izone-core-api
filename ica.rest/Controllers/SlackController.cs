using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Izone.Model;
using Izone.DB;

namespace Izone.API.Controllers
{
    [Route("[controller]")]
    public class SlackController : Controller
    {
        [HttpPost]
        public SlackResponse Post([FromForm] SlackPayload payload)
        {
            Console.WriteLine("Received POST request from Slack, or so I think anyway.");
            Console.WriteLine("User ID: " + payload.user_id);

            ITimeEntryRepository timeEntryRepository = new TimeEntryRepository();
            var timeEntries = timeEntryRepository.List();

            var response = new SlackResponse
            {
                Text = "Your time entries for week <week>. " + payload.user_id + " " + payload.user_name,
                Attachments = new List<SlackResponse>()
            };

            foreach (var timeEntry in timeEntries)
            {
                response.Attachments.Add(new SlackResponse
                {
                    Text = string.Format("{0}: {1} h", timeEntry.Alias, timeEntry.Hours),
                    SlackColor = SlackColor.danger
                });
            }

            return response;
        }
    }

    public class SlackPayload
    {
        public string user_id { get; set; }
        public string user_name { get; set; }
    }
}
