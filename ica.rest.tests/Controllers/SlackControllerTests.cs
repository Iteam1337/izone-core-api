using System;
using Xunit;
using Moq;
using FluentAssertions;
using ica.rest.Controllers;
using ica.model;
using ica.model.REST;
using ica.database;
using System.Collections.Generic;

namespace ica.rest.tests.Controllers
{
    public class SlackControllerTests
    {
        private readonly SlackController _slackController;
        private readonly Mock<IPersonRepository> _personRepository;
        private readonly Mock<ITimeEntryRepository> _timeEntryRepository;

        private SlackRequestPayload payload = new SlackRequestPayload
        {
            user_id = "C47",
            user_name = "kittycat"
        };

        private Person person = new Person
        {
            Firstname = "Kitty",
            Lastname = "Cat",
            IzoneUsername = "KCT",
            SlackUsername = "kittycat"
        };

        public SlackControllerTests()
        {
            _personRepository = new Mock<IPersonRepository>();
            _timeEntryRepository = new Mock<ITimeEntryRepository>();

            // Some general setups.
            _personRepository.Setup(x => x.GetBySlackId(It.IsAny<string>())).Returns(person);
            _timeEntryRepository.Setup(x => x.List()).Returns(new List<TimeEntry>());

            // Create the Controller to be tested and inject mocks..
            _slackController = new SlackController(_personRepository.Object, _timeEntryRepository.Object);
        }

        [Fact]
        public void POST_slack_calls_PersonRepository()
        {
            _slackController.Post(payload);
            _personRepository.Verify(x => x.GetBySlackId(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void POST_slack_calls_TimeEntryRepository()
        {
            _slackController.Post(payload);
            _timeEntryRepository.Verify(x => x.List(), Times.Once());
        }
    }
}
