using Izone.Model;
using System.Collections.Generic;

namespace Izone.DB
{
    interface IPersonRepository
    {
        List<Person> List();
    }
}
