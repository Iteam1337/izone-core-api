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

        [Fact]
        public void POST_slack_attempts_to_get_user_by_name_if_not_found_by_id()
        {
            var req = new SlackRequestPayload
            {
                user_id = "some id",
                user_name = "some name"
            };

            _personRepository.Setup(x => x.GetBySlackId(req.user_id)).Returns<Person>(null);
            _personRepository.Setup(x => x.GetBySlackUsername(req.user_name)).Returns(person);

            _slackController.Post(req);
            _personRepository.Verify(x => x.GetBySlackId(req.user_id), Times.Once());
            _personRepository.Verify(x => x.GetBySlackUsername(req.user_name), Times.Once());
        }

        [Fact]
        public void POST_slack_attempts_to_update_Person_with_id_if_user_was_mapped_using_name()
        {
            var req = new SlackRequestPayload
            {
                user_id = "some id",
                user_name = "some name"
            };

            _personRepository.Setup(x => x.GetBySlackId(req.user_id)).Returns<Person>(null);
            _personRepository.Setup(x => x.GetBySlackUsername(req.user_name)).Returns(person);

            _slackController.Post(req);
            _personRepository.Verify(x => x.SetSlackId(It.IsAny<Person>()), Times.Once());
        }

        [Fact]
        public void POST_slack_returns_proper_error_message_if_no_Person_can_be_mapped()
        {
            _personRepository.Setup(x => x.GetBySlackId(It.IsAny<string>())).Returns<Person>(null);
            _personRepository.Setup(x => x.GetBySlackUsername(It.IsAny<string>())).Returns<Person>(null);

            var response =_slackController.Post(payload);
            response.Text.Should().Be("Something went wrong.");
            response.Attachments[0].SlackColor.Should().Be(SlackColor.danger);
            response.Attachments[0].Text.Should().Be(string.Format("Your account needs to be setup in izone before you can use this command. <{0}|{1}>", payload.user_name, payload.user_id));
        }
    }
}
