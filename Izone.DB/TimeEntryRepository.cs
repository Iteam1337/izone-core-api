using System;
using System.Linq;
using System.Collections.Generic;
using Izone.Model;

namespace Izone.DB
{
    public class TimeEntryRepository : ITimeEntryRepository
    {
        public List<TimeEntry> List()
        {
            using (var db = new IzoneContext())
            {
                return db.TimeEntries.Take(10).ToList();
            }
        }
    }
}
