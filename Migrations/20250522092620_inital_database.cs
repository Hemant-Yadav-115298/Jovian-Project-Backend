using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jovian_Project_Backend.Migrations
{
    /// <inheritdoc />
    public partial class inital_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RepoName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ScanDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUpdated = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ActorsActor",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InfoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsUpdated = table.Column<bool>(type: "bit", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Justification = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorsActor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActorsActor_Actors_ActorID",
                        column: x => x.ActorID,
                        principalTable: "Actors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorsActor_Info_InfoID",
                        column: x => x.InfoID,
                        principalTable: "Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Threat",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InfoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ScanDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScanID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThreatTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThreatDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categories = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remediation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThreatDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Justification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Risk = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsUpdated = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Threat_Info_InfoID",
                        column: x => x.InfoID,
                        principalTable: "Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThreatDiagram",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InfoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SequenceDiagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlowDiagram = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreatDiagram", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ThreatDiagram_Info_InfoID",
                        column: x => x.InfoID,
                        principalTable: "Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorsActor_ActorID",
                table: "ActorsActor",
                column: "ActorID");

            migrationBuilder.CreateIndex(
                name: "IX_ActorsActor_InfoID",
                table: "ActorsActor",
                column: "InfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Threat_InfoID",
                table: "Threat",
                column: "InfoID");

            migrationBuilder.CreateIndex(
                name: "IX_ThreatDiagram_InfoID",
                table: "ThreatDiagram",
                column: "InfoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorsActor");

            migrationBuilder.DropTable(
                name: "Threat");

            migrationBuilder.DropTable(
                name: "ThreatDiagram");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Info");
        }
    }
}
