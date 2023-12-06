using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDiffciltiesandregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("05abb55d-3f75-471a-8f05-c8e8c506f15d"), "Medium" },
                    { new Guid("cd6666fd-6d2f-4a1b-a2c3-8bc1ca0e74c1"), "Easy" },
                    { new Guid("ceb67693-65ed-4975-be6d-3755069ad11b"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageURL" },
                values: new object[,]
                {
                    { new Guid("c0ece3dd-d65a-4d74-ad1b-b83f2e46cc30"), "Ptr", "Penturu", "Penturu-Image.png" },
                    { new Guid("d450126e-1ed2-4e9c-801d-bfd0d51be7c2"), "Bng", "Bangalore", "Bangalore-image.jpg" },
                    { new Guid("fb7aec7f-d049-497a-abe4-5616afccfd47"), "hyd", "Hyderabad", "SOme-image.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("05abb55d-3f75-471a-8f05-c8e8c506f15d"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cd6666fd-6d2f-4a1b-a2c3-8bc1ca0e74c1"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ceb67693-65ed-4975-be6d-3755069ad11b"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("c0ece3dd-d65a-4d74-ad1b-b83f2e46cc30"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("d450126e-1ed2-4e9c-801d-bfd0d51be7c2"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("fb7aec7f-d049-497a-abe4-5616afccfd47"));
        }
    }
}
