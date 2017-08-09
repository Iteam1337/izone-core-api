using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ica.database.migrations;

namespace ica.database.migrations.Migrations
{
    [DbContext(typeof(DBMigrationsContext))]
    [Migration("20170809185615_ExtendPersonWithSlackInfo")]
    partial class ExtendPersonWithSlackInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ica.database.migrations.JobLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("jl_id");

                    b.HasKey("Id");

                    b.ToTable("job_log_db");
                });
        }
    }
}
