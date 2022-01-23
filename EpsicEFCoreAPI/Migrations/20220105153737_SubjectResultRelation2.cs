using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpsicEFCoreAPI.Migrations
{
    public partial class SubjectResultRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_Subject",
                table: "Results");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Subject",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
