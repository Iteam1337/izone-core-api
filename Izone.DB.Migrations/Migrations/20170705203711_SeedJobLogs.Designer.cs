﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Izone.DB.Migrations;

namespace Izone.DB.Migrations.Migrations
{
    [DbContext(typeof(DBMigrationsContext))]
    [Migration("20170705203711_SeedJobLogs")]
    partial class SeedJobLogs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Izone.DB.Migrations.JobLog", b =>
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