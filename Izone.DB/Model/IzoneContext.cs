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
    }
}
