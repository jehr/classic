using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class createModelValoration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Valorations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    DateValoration = table.Column<DateTime>(nullable: false),
                    Hour = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valorations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Valorations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailsValoration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorationId = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    MeasureArmLeft = table.Column<int>(nullable: false),
                    MeasureArmRight = table.Column<int>(nullable: false),
                    MeasureForearmLeft = table.Column<int>(nullable: false),
                    MeasureForearmRight = table.Column<int>(nullable: false),
                    MeasureLegLeft = table.Column<int>(nullable: false),
                    MeasureLegRight = table.Column<int>(nullable: false),
                    MeasureCalfLeft = table.Column<int>(nullable: false),
                    MeasureCalfRight = table.Column<int>(nullable: false),
                    MeasureHead = table.Column<int>(nullable: false),
                    MeasureNeck = table.Column<int>(nullable: false),
                    MeasureChest = table.Column<int>(nullable: false),
                    MeasureBack = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsValoration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailsValoration_Valorations_ValorationId",
                        column: x => x.ValorationId,
                        principalTable: "Valorations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailsValoration_ValorationId",
                table: "DetailsValoration",
                column: "ValorationId");

            migrationBuilder.CreateIndex(
                name: "IX_Valorations_UserId",
                table: "Valorations",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailsValoration");

            migrationBuilder.DropTable(
                name: "Valorations");
        }
    }
}
