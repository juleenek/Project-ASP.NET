using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrumAdopcyjneZwierzat.Migrations
{
    public partial class AdoptionCenter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boxes",
                columns: table => new
                {
                    BoxId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BoxName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoxAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxes", x => x.BoxId);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    DogId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DogName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Breed = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    DogBirthYear = table.Column<int>(type: "int", nullable: false),
                    BoxId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VolunteerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.DogId);
                    table.ForeignKey(
                        name: "FK_Dogs_Boxes_BoxId",
                        column: x => x.BoxId,
                        principalTable: "Boxes",
                        principalColumn: "BoxId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    VolunteerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VolunteerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolunteerLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolunteerPesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolunteerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolunteerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.VolunteerId);
                    table.ForeignKey(
                        name: "FK_Volunteers_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "DogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoxVolunteer",
                columns: table => new
                {
                    BoxesBoxId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VolunteersVolunteerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxVolunteer", x => new { x.BoxesBoxId, x.VolunteersVolunteerId });
                    table.ForeignKey(
                        name: "FK_BoxVolunteer_Boxes_BoxesBoxId",
                        column: x => x.BoxesBoxId,
                        principalTable: "Boxes",
                        principalColumn: "BoxId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoxVolunteer_Volunteers_VolunteersVolunteerId",
                        column: x => x.VolunteersVolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "VolunteerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoxVolunteer_VolunteersVolunteerId",
                table: "BoxVolunteer",
                column: "VolunteersVolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_BoxId",
                table: "Dogs",
                column: "BoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_DogId",
                table: "Volunteers",
                column: "DogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoxVolunteer");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Boxes");
        }
    }
}
