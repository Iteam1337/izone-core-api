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
}
