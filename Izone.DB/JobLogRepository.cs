using System;
using System.Linq;
using System.Collections.Generic;
using Izone.Model;
using Izone.DB.Model;

namespace Izone.DB
{
    public interface IJobLogRepository {
        List<JobLog> List();
    }

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
