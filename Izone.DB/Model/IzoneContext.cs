using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
          optionsBuilder.UseSqlServer(@"Data Source=kritvit; Database=izone; User ID=izone-life; Password=3djeNovember;");
      }
    }

    [Table("job_log_db")]
    public class JobLog
    {
        [Column("jl_id")]
        public int Id { get; set; }
    }
}
