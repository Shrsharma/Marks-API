using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ModifiedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubjID",
                table: "SubjectModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjID",
                table: "SubjectModel");
        }
    }
}
