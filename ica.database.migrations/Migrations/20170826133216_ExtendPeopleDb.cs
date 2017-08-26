using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ica.database.migrations.Migrations
{
    public partial class ExtendPeopleDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>("p_firstname", "people_db");
            migrationBuilder.AddColumn<string>("p_lastname", "people_db");
            migrationBuilder.AddColumn<string>("p_izusername", "people_db");
            migrationBuilder.AddColumn<string>("p_email", "people_db");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("p_firstname", "people_db");
            migrationBuilder.DropColumn("p_lastname", "people_db");
            migrationBuilder.DropColumn("p_izusername", "people_db");
            migrationBuilder.DropColumn("p_email", "people_db");
        }
    }
}
