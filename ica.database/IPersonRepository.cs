using ica.model;
using System.Collections.Generic;

namespace ica.database
{
    public interface IPersonRepository
    {
        List<Person> List();
        Person GetBySlackId(string slackId);
        Person GetBySlackUsername(string slackUserName);

        void SetSlackId(Person person);
    }
}
