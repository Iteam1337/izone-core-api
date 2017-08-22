using System.Linq;
using ica.model;
using System.Collections.Generic;

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
    }
}