using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mancs_radar_server.Migrations
{
    /// <inheritdoc />
    public partial class DogLocationAndPin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Addresses_LastSeenAddressId",
                table: "Dogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_DogBreed_BreedId",
                table: "Dogs");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Dogs_Reporter",
                table: "Dogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DogBreed",
                table: "DogBreed");

            migrationBuilder.RenameTable(
                name: "DogBreed",
                newName: "DogBreeds");

            migrationBuilder.RenameIndex(
                name: "IX_DogBreed_Name",
                table: "DogBreeds",
                newName: "IX_DogBreeds_Name");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Dogs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactInfo",
                table: "Dogs",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Dogs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditPinCode",
                table: "Dogs",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DogBreeds",
                table: "DogBreeds",
                column: "Id");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Dogs_Reporter",
                table: "Dogs",
                sql: "([ReporterUserId] IS NOT NULL AND [ReporterShelterId] IS NULL) OR ([ReporterUserId] IS NULL AND [ReporterShelterId] IS NULL)");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Addresses_LastSeenAddressId",
                table: "Dogs",
                column: "LastSeenAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_DogBreeds_BreedId",
                table: "Dogs",
                column: "BreedId",
                principalTable: "DogBreeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Addresses_LastSeenAddressId",
                table: "Dogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_DogBreeds_BreedId",
                table: "Dogs");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Dogs_Reporter",
                table: "Dogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DogBreeds",
                table: "DogBreeds");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "ContactInfo",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "EditPinCode",
                table: "Dogs");

            migrationBuilder.RenameTable(
                name: "DogBreeds",
                newName: "DogBreed");

            migrationBuilder.RenameIndex(
                name: "IX_DogBreeds_Name",
                table: "DogBreed",
                newName: "IX_DogBreed_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DogBreed",
                table: "DogBreed",
                column: "Id");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Dogs_Reporter",
                table: "Dogs",
                sql: "([ReporterUserId] IS NOT NULL AND [ReporterShelterId] IS NULL) OR ([ReporterUserId] IS NULL AND [ReporterShelterId] IS NOT NULL)");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Addresses_LastSeenAddressId",
                table: "Dogs",
                column: "LastSeenAddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_DogBreed_BreedId",
                table: "Dogs",
                column: "BreedId",
                principalTable: "DogBreed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
