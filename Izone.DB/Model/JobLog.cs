using System.ComponentModel.DataAnnotations.Schema;

namespace Izone.DB.Model
{
    [Table("job_log_db")]
    public class JobLog
    {
        [Column("jl_id")]
        public int Id { get; set; }

        [Column("jl_id")]
        public int JobId { get; set; }

        [Column("jl_alias")]
        public string Alias { get; set; }

        [Column("jl_description")]
        public string Description { get; set; }
        
        [Column("jl_executor")]
        public string Executor { get; set; }
        
        [Column("jl_hours")]
        public double Hours { get; set; }

        [Column("jl_starttime")]
        public DateTime StartTime { get; set; }

        [Column("jl_endtime")]
        public DateTime EndTime { get; set; }

        [Column("jl_gcal_id")]
        public string GoogleCalendarId { get; set; }
    }
}