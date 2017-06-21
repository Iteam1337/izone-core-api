using System;
using Izone.Model;
using System.Collections.Generic;

namespace Izone.DB
{
    public interface IClient {
        List<TimeEntry> GetCalendar(string week);
    }

    public class Client : IClient
    {
        public List<TimeEntry> GetCalendar(string week)
        {
            return new List<TimeEntry>();
        }
    }
}
