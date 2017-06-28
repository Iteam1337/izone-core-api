using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Izone.Model;

namespace Izone.DB
{
    public class IzoneContext : DbContext
    {
      public DbSet<TimeEntry> TimeEntries { get; set; }
      public DbSet<Person> People { get; set; }

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
}
