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
          optionsBuilder.UseSqlServer(@"Data Source=sql; Database=izone-dev; User ID=sa; Password=ved-enozi;");
      }
    }

    [Table("job_log_db")]
    public class JobLog
    {
        [Column("jl_id")]
        public int Id { get; set; }
    }
}
