using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Izone.DB.Migrations
{
    public class DBMigrationsContext : DbContext
    {
      public DbSet<JobLog> JobLogs { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
          var connectionString = Environment.GetEnvironmentVariable("DB__CONNECTIONSTRING");
          if (string.IsNullOrEmpty(connectionString))
            connectionString = @"Data Source=sql; Database=izone-dev; User ID=sa; Password=ved-enozi;";
          optionsBuilder.UseSqlServer(connectionString);
      }
    }

    [Table("job_log_db")]
    public class JobLog
    {
        [Column("jl_id")]
        public int Id { get; set; }
    }
}
