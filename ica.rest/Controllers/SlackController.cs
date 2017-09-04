using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ica.model;
using ica.model.REST;
using ica.database;

namespace ica.rest.Controllers
{
    [Route("[controller]")]
    public class SlackController : Controller
    {
        public readonly IPersonRepository _personRepository;
        public readonly ITimeEntryRepository _timeEntryRepository;

        public SlackController(IPersonRepository personRepository, ITimeEntryRepository timeEntryRepository)
        {
            _personRepository = personRepository;
            _timeEntryRepository = timeEntryRepository;
        }

        [HttpPost]
        public SlackResponse Post([FromForm] SlackRequestPayload payload)
        {
            Console.WriteLine("Received POST /slack");
            Console.WriteLine("User ID: " + payload.user_id);
            Console.WriteLine("Username: " + payload.user_name);

            var response = new SlackResponse
            {
                Attachments = new List<SlackResponse>()
            };

            var person = GetPerson(payload.user_id, payload.user_name);

            if (person == null) {
                response.Text = "Something went wrong.";
                response.Attachments.Add(new SlackResponse
                {
                    Text = string.Format("Your account needs to be setup in izone before you can use this command. <{0}|{1}>", payload.user_name, payload.user_id),
                    SlackColor = SlackColor.danger
                });
                return response;
            }

            var timeEntries = _timeEntryRepository.List();

            response.Text = string.Format("Week {0} for {1} ({2} {3})", "<week>", person.IzoneUsername.ToUpper(), person.Firstname, person.Lastname);

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

        Person GetPerson(string slackId, string slackUsername)
        {
            var person = _personRepository.GetBySlackId(slackId);

            if (person != null)
                return person;

            person = _personRepository.GetBySlackUsername(slackUsername);
            
            if (person != null) {   
                // Update Person and save SlackId.
                person.SlackId = slackId;
                _personRepository.SetSlackId(person);
            }

            return person;
        }
    }
}
