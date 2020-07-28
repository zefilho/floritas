using Microsoft.EntityFrameworkCore.Migrations;

namespace FloritasStore.Data.Migrations
{
    public partial class AddColumnPhoneNumberToTableCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Company",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Company");
        }
    }
}
