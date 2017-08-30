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

            var person = GetPerson(payload.user_id, payload.user_name);

            Console.WriteLine("Mapped user to Person " + person.Firstname + " " + person.Lastname);

            var timeEntries = _timeEntryRepository.List();

            var response = new SlackResponse
            {
                Text = string.Format("Week {0} for {1} ({2} {3})", "<week>", person.IzoneUsername.ToUpper(), person.Firstname, person.Lastname),
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

        Person GetPerson(string slackId, string slackUsername)
        {
            var person = _personRepository.GetBySlackId(slackId);

            if (person == null)
                person = _personRepository.GetBySlackUsername(slackUsername);
            
            if (person == null)
                throw new Exception(string.Format("Could not find a person having SlackId {0} or SlackUsername {1}", slackId, slackUsername));
            
            // Update Person and save SlackId.
            person.SlackId = slackId;
            _personRepository.SetSlackId(person);

            return person;
        }
    }
}
