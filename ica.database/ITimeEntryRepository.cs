using System;
using System.Linq;
using System.Collections.Generic;
using ica.model;

namespace ica.database
{
    public interface ITimeEntryRepository {
        List<TimeEntry> List();
        double TotalHours();
    }
}
