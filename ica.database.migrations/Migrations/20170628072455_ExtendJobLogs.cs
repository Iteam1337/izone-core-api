using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ica.database.migrations.Migrations
{
    public partial class ExtendJobLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>("jl_job_id", "job_log_db");

            migrationBuilder.AddColumn<double>("jl_hours", "job_log_db");

            migrationBuilder.AddColumn<string>("jl_alias", "job_log_db");
            migrationBuilder.AddColumn<string>("jl_executor", "job_log_db");
            migrationBuilder.AddColumn<string>("jl_description", "job_log_db");
            migrationBuilder.AddColumn<string>("jl_gcal_id", "job_log_db");

            migrationBuilder.AddColumn<DateTime>("jl_starttime", "job_log_db");
            migrationBuilder.AddColumn<DateTime>("jl_endtime", "job_log_db");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("jl_job_id", "job_log_db");
            migrationBuilder.DropColumn("jl_hours", "job_log_db");
            migrationBuilder.DropColumn("jl_alias", "job_log_db");
            migrationBuilder.DropColumn("jl_executor", "job_log_db");
            migrationBuilder.DropColumn("jl_description", "job_log_db");
            migrationBuilder.DropColumn("jl_gcal_id", "job_log_db");
            migrationBuilder.DropColumn("jl_starttime", "job_log_db");
            migrationBuilder.DropColumn("jl_endtime", "job_log_db");
        }
    }
}
