using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpsicEFCoreAPI.Migrations
{
    public partial class SubjectResultRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectId_Subject",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id_Result = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Result = table.Column<double>(type: "float", nullable: false),
                    SubjectId_Subject = table.Column<int>(type: "int", nullable: false),
                    Id_Subject = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id_Result);
                    table.ForeignKey(
                        name: "FK_Results_Subjects_SubjectId_Subject",
                        column: x => x.SubjectId_Subject,
                        principalTable: "Subjects",
                        principalColumn: "Id_Subject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubjectId_Subject",
                table: "Users",
                column: "SubjectId_Subject");

            migrationBuilder.CreateIndex(
                name: "IX_Results_SubjectId_Subject",
                table: "Results",
                column: "SubjectId_Subject");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Subjects_SubjectId_Subject",
                table: "Users",
                column: "SubjectId_Subject",
                principalTable: "Subjects",
                principalColumn: "Id_Subject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Subjects_SubjectId_Subject",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Users_SubjectId_Subject",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SubjectId_Subject",
                table: "Users");
        }
    }
}
