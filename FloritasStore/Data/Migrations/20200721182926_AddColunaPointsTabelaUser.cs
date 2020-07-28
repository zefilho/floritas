using Microsoft.EntityFrameworkCore.Migrations;

namespace FloritasStore.Data.Migrations
{
    public partial class AddColunaPointsTabelaUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPoints",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPoints",
                table: "AspNetUsers");
        }
    }
}
