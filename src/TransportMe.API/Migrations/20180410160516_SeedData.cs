using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportMe.API.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "England", "London" },
                    { 2, "Japan", "Tokyo" }
                });

            migrationBuilder.InsertData(
                table: "TransportMode",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Bus" },
                    { 2, null, "Cable Car" },
                    { 3, null, "Cycle Hire" },
                    { 4, null, "Dlr" },
                    { 5, null, "National Rail" },
                    { 6, null, "Overground" },
                    { 7, null, "River Bus" },
                    { 8, null, "TFL Rail" },
                    { 9, null, "Tram" },
                    { 10, null, "Tube" }
                });

            migrationBuilder.InsertData(
                table: "TransportService",
                columns: new[] { "Id", "CityId", "Description", "Name", "TransportModeId" },
                values: new object[,]
                {
                    { 1, 1, null, "Bakerloo", 10 },
                    { 2, 1, null, "Central", 10 },
                    { 3, 1, null, "Circle", 10 },
                    { 4, 1, null, "District", 10 },
                    { 5, 1, null, "Hammersmith & City", 10 },
                    { 6, 1, null, "Jubilee", 10 },
                    { 7, 1, null, "Metropolitan", 10 },
                    { 8, 1, null, "Northern", 10 },
                    { 9, 1, null, "Piccadilly", 10 },
                    { 10, 1, null, "Victoria", 10 },
                    { 11, 1, null, "Waterloo & City", 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TransportMode",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransportMode",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TransportMode",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TransportMode",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TransportMode",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TransportMode",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TransportMode",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TransportMode",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TransportMode",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TransportService",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransportService",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TransportService",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TransportService",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TransportService",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TransportService",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TransportService",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TransportService",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TransportService",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TransportService",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TransportService",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransportMode",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
