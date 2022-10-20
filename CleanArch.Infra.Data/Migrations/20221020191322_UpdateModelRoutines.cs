using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class UpdateModelRoutines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routines_LevelRoutines_LevelRoutinesId",
                table: "Routines");

            migrationBuilder.DropIndex(
                name: "IX_Routines_LevelRoutinesId",
                table: "Routines");

            migrationBuilder.DropColumn(
                name: "LevelRoutinesId",
                table: "Routines");

            migrationBuilder.CreateIndex(
                name: "IX_Routines_LevelId",
                table: "Routines",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routines_LevelRoutines_LevelId",
                table: "Routines",
                column: "LevelId",
                principalTable: "LevelRoutines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routines_LevelRoutines_LevelId",
                table: "Routines");

            migrationBuilder.DropIndex(
                name: "IX_Routines_LevelId",
                table: "Routines");

            migrationBuilder.AddColumn<int>(
                name: "LevelRoutinesId",
                table: "Routines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routines_LevelRoutinesId",
                table: "Routines",
                column: "LevelRoutinesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routines_LevelRoutines_LevelRoutinesId",
                table: "Routines",
                column: "LevelRoutinesId",
                principalTable: "LevelRoutines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
