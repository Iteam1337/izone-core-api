using ica.model;
using System.Collections.Generic;

namespace ica.database
{
    interface IPersonRepository
    {
        List<Person> List();
    }
}
