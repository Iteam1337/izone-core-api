using System.Linq;
using Izone.Model;
using System.Collections.Generic;

namespace Izone.DB
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
    }
}
