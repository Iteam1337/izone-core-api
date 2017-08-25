using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ica.database.migrations.Migrations
{
    public partial class AddSlackFieldsToPeopleDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>("p_slack_id", "people_db");
            migrationBuilder.AddColumn<string>("p_slack_username", "people_db");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("p_slack_id", "people_db");
            migrationBuilder.DropColumn("p_slack_username", "people_db");
        }
    }
}
