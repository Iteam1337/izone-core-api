using System.Linq;
using ica.model;
using System.Collections.Generic;
using System;

namespace ica.database
{
    public class PersonRepository : IPersonRepository
    {
        public List<Person> List()
        {
            using (var db = new IzoneContext())
            {
                return db.People.ToList();
            }
        }

        public Person GetBySlackId(string slackId)
        {
            using (var db = new IzoneContext())
            {
                return db.People.Where(x => x.SlackId == slackId).FirstOrDefault();
            }
        }

        public Person GetBySlackUsername(string slackUsername)
        {
            using (var db = new IzoneContext())
            {
                return db.People.Where(x => x.SlackUsername == slackUsername).FirstOrDefault();
            }
        }

        public void SetSlackId(Person person)
        {
            using (var db = new IzoneContext())
            {
                var dbPerson = db.People.Where(x => x.SlackUsername == person.SlackUsername).FirstOrDefault();

                if (dbPerson == null)
                    throw new Exception(string.Format("Cannot find Person having slack username '{0}'", person.SlackUsername));
                
                dbPerson.SlackId = person.SlackId;
                db.Update(dbPerson);
                db.SaveChanges();
            }
        }
    }
}
