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
        // POST api/values
        [HttpPost]
        public SlackResponse Post()
        {
            IJobLogRepository jobLogRepository = new JobLogRepository();
            var jobLogs = jobLogRepository.List();

            var response = new SlackResponse
            {
                Text = "Your time entries for week <week>",
                Attachments = new List<SlackResponse>()
            };

            var att = new SlackResponse
            {
                Text = "iteamvs: 4 h",
                SlackColor = SlackColor.good
            };
            response.Attachments.Add(att);

            foreach (var jobLog in jobLogs)
            {
                response.Attachments.Add(new SlackResponse
                {
                    Text = string.Format("{0}: {1} h", jobLog.Alias, jobLog.Hours),
                    SlackColor = SlackColor.danger
                });
            }

            return response;
        }
    }
}
