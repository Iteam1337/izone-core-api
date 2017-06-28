using System.Linq;
using Izone.DB.Model;
using System.Collections.Generic;

namespace Izone.DB
{
    interface IPersonRepository
    {
        List<Person> List();
    }

    public class PersonRepository : IPersonRepository
    {
        public List<Person> List()
        {
            using (var db = new IzoneContext())
            {
                return db.People.ToList();
            }
        }
    }
}
