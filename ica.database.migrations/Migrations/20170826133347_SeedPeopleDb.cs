using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ica.database.migrations.Migrations
{
    public partial class SeedPeopleDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO people_db
                (
                     p_id
                    ,p_firstname
                    ,p_lastname
                    ,p_izusername
                    ,p_email
                    ,p_slack_id
                    ,p_slack_username
                )
                VALUES
                (
                     1
                    ,'Kisse'
                    ,'Katt'
                    ,'cat'
                    ,'cat@iteam.se'
                    ,'U0260BV6S'
                    ,'ilix'
                )
            "
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM people_db
                WHERE p_id = 1
            "
            );
        }
    }
}
