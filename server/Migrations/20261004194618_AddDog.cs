using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace mancs_radar_server.Migrations
{
    /// <inheritdoc />
    public partial class AddDog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChipNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ReportType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastSeenLocation = table.Column<Point>(type: "geography", nullable: false),
                    LastSeenAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReporterUserId = table.Column<int>(type: "int", nullable: true),
                    ReporterShelterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                    table.CheckConstraint("CK_Dogs_Reporter", "([ReporterUserId] IS NOT NULL AND [ReporterShelterId] IS NULL) OR ([ReporterUserId] IS NULL AND [ReporterShelterId] IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_Dogs_Shelters_ReporterShelterId",
                        column: x => x.ReporterShelterId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dogs_Users_ReporterUserId",
                        column: x => x.ReporterUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DogPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    DogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DogPhotos_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DogPhotos_DogId",
                table: "DogPhotos",
                column: "DogId",
                unique: true,
                filter: "[IsDefault] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_ChipNumber",
                table: "Dogs",
                column: "ChipNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_ReporterShelterId",
                table: "Dogs",
                column: "ReporterShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_ReporterUserId",
                table: "Dogs",
                column: "ReporterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_ReportType_Status",
                table: "Dogs",
                columns: new[] { "ReportType", "Status" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogPhotos");

            migrationBuilder.DropTable(
                name: "Dogs");
        }
    }
}
