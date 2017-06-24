using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Izone.Model;

namespace Izone.API.Controllers
{
    [Route("[controller]")]
    public class SlackController : Controller
    {
        // POST api/values
        [HttpPost]
        public SlackResponse Post()
        {
            var response = new SlackResponse
            {
                Text = "Meow!",
                Attachments = new List<SlackResponse>()
            };

            var att = new SlackResponse
            {
                Text = "iteamvs: 4 h",
                SlackColor = SlackColor.good
            };
            response.Attachments.Add(att);

            return response;
        }
    }
}
