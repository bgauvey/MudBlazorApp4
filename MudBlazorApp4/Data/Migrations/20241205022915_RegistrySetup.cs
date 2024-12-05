using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TLC.Registry.Migrations
{
    /// <inheritdoc />
    public partial class RegistrySetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breeders",
                columns: table => new
                {
                    BreederId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FarmName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HerdPrefix = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeders", x => x.BreederId);
                });

            migrationBuilder.CreateTable(
                name: "classifications",
                columns: table => new
                {
                    ClassificationCd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassificationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classifications", x => x.ClassificationCd);
                });

            migrationBuilder.CreateTable(
                name: "dna_status",
                columns: table => new
                {
                    StatusCd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dna_status", x => x.StatusCd);
                });

            migrationBuilder.CreateTable(
                name: "Registries",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassificationCd = table.Column<int>(type: "int", nullable: false),
                    BreederId = table.Column<int>(type: "int", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bloodline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BirthRank = table.Column<int>(type: "int", nullable: true),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DnaStatusStatusCd = table.Column<int>(type: "int", nullable: false),
                    BDI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MicroChip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TattooLeft = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TattooRight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sire_registration_id = table.Column<int>(type: "int", nullable: true),
                    dam_registration_id = table.Column<int>(type: "int", nullable: true),
                    BirthWeight = table.Column<float>(type: "real", nullable: true),
                    ThirtyDayWeight = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registries", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registries_Breeders_BreederId",
                        column: x => x.BreederId,
                        principalTable: "Breeders",
                        principalColumn: "BreederId");
                    table.ForeignKey(
                        name: "FK_Registries_classifications_ClassificationCd",
                        column: x => x.ClassificationCd,
                        principalTable: "classifications",
                        principalColumn: "ClassificationCd",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registries_dna_status_DnaStatusStatusCd",
                        column: x => x.DnaStatusStatusCd,
                        principalTable: "dna_status",
                        principalColumn: "StatusCd",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registries_BreederId",
                table: "Registries",
                column: "BreederId");

            migrationBuilder.CreateIndex(
                name: "IX_Registries_ClassificationCd",
                table: "Registries",
                column: "ClassificationCd");

            migrationBuilder.CreateIndex(
                name: "IX_Registries_DnaStatusStatusCd",
                table: "Registries",
                column: "DnaStatusStatusCd");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registries");

            migrationBuilder.DropTable(
                name: "Breeders");

            migrationBuilder.DropTable(
                name: "classifications");

            migrationBuilder.DropTable(
                name: "dna_status");
        }
    }
}
