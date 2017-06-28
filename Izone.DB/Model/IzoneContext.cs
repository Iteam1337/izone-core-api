using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Izone.DB.Model
{
    public class IzoneContext : DbContext
    {
      public DbSet<JobLog> JobLogs { get; set; }

      public IzoneContext()
      {
          Database.SetCommandTimeout(150000);
      }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
          var connectionString = Environment.GetEnvironmentVariable("DB__CONNECTIONSTRING");
          if (string.IsNullOrEmpty(connectionString))
            connectionString = @"Data Source=sql; Database=the-dev-db; User ID=sa; Password=password;";

          optionsBuilder.UseSqlServer(connectionString);

      }
    }

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
