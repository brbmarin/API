using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "Price", "PublishDate", "Remarks", "Title" },
                values: new object[,]
                {
                    { 1, "Christian Nagel", "A true masterclass in C# and .NET programming", "Software", 50m, new DateTime(2016, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Professional C# 6 and .NET Core 1.0" },
                    { 2, "Christian Nagel", "A true masterclass in C# and .NET programming", "Software", 50m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Professional C# 7 and .NET Core 2.0" },
                    { 3, "Christian Nagel", "A true masterclass in C# and .NET programming", "Software", 50m, new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Professional C# 8 and .NET Core 3.0" },
                    { 4, "Christian Nagel", "A true masterclass in C# and .NET programming", "Software", 50m, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Professional C# 9 and .NET 5" },
                    { 5, "Perkins, Reid, and Hammer", "The perfect guide to Visual C#", "Software", 45m, new DateTime(2020, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beginning Visual C# 2019" },
                    { 6, "Andrew Troelsen", "The ultimate C# resource", "Software", 50m, new DateTime(2017, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pro C# 7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
