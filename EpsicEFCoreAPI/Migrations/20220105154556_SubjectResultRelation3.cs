using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpsicEFCoreAPI.Migrations
{
    public partial class SubjectResultRelation3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Subjects_SubjectId_Subject",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SubjectId_Subject",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SubjectId_Subject",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectId_Subject",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubjectId_Subject",
                table: "Users",
                column: "SubjectId_Subject");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Subjects_SubjectId_Subject",
                table: "Users",
                column: "SubjectId_Subject",
                principalTable: "Subjects",
                principalColumn: "Id_Subject");
        }
    }
}
