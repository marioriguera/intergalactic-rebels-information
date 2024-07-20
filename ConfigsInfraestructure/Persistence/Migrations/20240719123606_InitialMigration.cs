using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConfigsInfraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HomeViewConfigs");

            migrationBuilder.CreateTable(
                name: "HomeViewSliders",
                schema: "HomeViewConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeViewSliders", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "HomeViewConfigs",
                table: "HomeViewSliders",
                columns: new[] { "Id", "Alt", "Src" },
                values: new object[,]
                {
                    { new Guid("9444b29d-f459-4ff2-bfc6-dacea6543288"), "Universe nebulosa", "https://wallpapers.com/images/hd/4k-universe-eta-carinae-nebula-2iqpijwfzmw3z4al.jpg" },
                    { new Guid("c4438db0-7b74-4f66-b37b-7259b1273c4a"), "Glowing ring", "https://wallpapers.com/images/hd/4k-space-glowing-ring-es4tss2e6i1dzfj6.jpg" },
                    { new Guid("e7bc13e9-0e2a-4ad1-83ae-1130c3862b3c"), "Wallpaper start", "https://wallpapersmug.com/download/3840x2160/d06c64/starry-space-milky-way-stars.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeViewSliders",
                schema: "HomeViewConfigs");
        }
    }
}
