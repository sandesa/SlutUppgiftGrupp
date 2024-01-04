using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepAway2._0.Migrations
{
    /// <inheritdoc />
    public partial class AddedSomeMoreAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CouncelorAssignments_Councelors_CouncelorId",
                table: "CouncelorAssignments");

            migrationBuilder.AlterColumn<int>(
                name: "CouncelorId",
                table: "CouncelorAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CouncelorAssignments_Councelors_CouncelorId",
                table: "CouncelorAssignments",
                column: "CouncelorId",
                principalTable: "Councelors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CouncelorAssignments_Councelors_CouncelorId",
                table: "CouncelorAssignments");

            migrationBuilder.AlterColumn<int>(
                name: "CouncelorId",
                table: "CouncelorAssignments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CouncelorAssignments_Councelors_CouncelorId",
                table: "CouncelorAssignments",
                column: "CouncelorId",
                principalTable: "Councelors",
                principalColumn: "Id");
        }
    }
}
