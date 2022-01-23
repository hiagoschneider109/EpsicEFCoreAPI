using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpsicEFCoreAPI.Migrations
{
    public partial class SubjectResultRelation4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Subjects_SubjectId_Subject",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "SubjectId_Subject",
                table: "Results",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_SubjectId_Subject",
                table: "Results",
                newName: "IX_Results_SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Subjects_SubjectId",
                table: "Results",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id_Subject",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Subjects_SubjectId",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Results",
                newName: "SubjectId_Subject");

            migrationBuilder.RenameIndex(
                name: "IX_Results_SubjectId",
                table: "Results",
                newName: "IX_Results_SubjectId_Subject");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Subjects_SubjectId_Subject",
                table: "Results",
                column: "SubjectId_Subject",
                principalTable: "Subjects",
                principalColumn: "Id_Subject",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
