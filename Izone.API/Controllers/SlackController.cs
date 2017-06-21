using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Izone.API.Controllers
{
    [Route("[controller]")]
    public class SlackController : Controller
    {
        // POST api/values
        [HttpPost]
        public dynamic Post([FromBody]string value)
        {
            return new {
                text = "testing"
            };
        }
    }
}
