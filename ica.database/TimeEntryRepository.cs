﻿using System;
using System.Linq;
using System.Collections.Generic;
using ica.model;

namespace ica.database
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

        double ITimeEntryRepository.TotalHours()
        {
            using (var db = new IzoneContext())
            {
                return db.TimeEntries.Sum(x => x.Hours);
            }
        }
    }
}
