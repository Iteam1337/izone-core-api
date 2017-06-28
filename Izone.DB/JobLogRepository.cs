using System;
using System.Linq;
using System.Collections.Generic;
using Izone.Model;
using Izone.DB.Model;

namespace Izone.DB
{
    public class JobLogRepository : IJobLogRepository
    {
        public List<JobLog> List()
        {
            using (var db = new IzoneContext())
            {
                return db.JobLogs.Take(10).ToList();
            }
        }
    }
}
