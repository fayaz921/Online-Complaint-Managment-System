using Microsoft.EntityFrameworkCore.Migrations;

namespace OCMS.Migrations
{
    public partial class addLocationinComplaintEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Complaints",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Complaints");
        }
    }
}
