using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportMe.Places.API.Infrastructure.Migrations
{
    public partial class IncludeAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                schema: "places",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                schema: "places",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                schema: "places",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                schema: "places",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_ZipCode",
                schema: "places",
                table: "Location",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                schema: "places",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                schema: "places",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Address_State",
                schema: "places",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                schema: "places",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Address_ZipCode",
                schema: "places",
                table: "Location");
        }
    }
}
