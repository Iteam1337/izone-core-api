using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Izone.DB.Migrations.Migrations
{
    public partial class SeedJobLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO job_log_db
                (
                     jl_job_id
                    ,jl_alias
                    ,jl_description
                    ,jl_executor
                    ,jl_hours
                    ,jl_starttime
                    ,jl_endtime
                    ,jl_gcal_id
                )
                VALUES
                (
                     1
                    ,'meow'
                    ,'purring and meoweing'
                    ,'acr'
                    ,2.5
                    ,'2017-01-02 10:15:00'
                    ,'2017-01-02 12:45:00'
                    ,'0123456789abcdef'
                )
            "
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM job_log_db
                WHERE 1 = 1
            "
            );
        }
    }
}
