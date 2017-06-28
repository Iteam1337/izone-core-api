using System;
using System.Linq;
using System.Collections.Generic;
using Izone.Model;

namespace Izone.DB
{
    public interface ITimeEntryRepository {
        List<TimeEntry> List();
    }
}
