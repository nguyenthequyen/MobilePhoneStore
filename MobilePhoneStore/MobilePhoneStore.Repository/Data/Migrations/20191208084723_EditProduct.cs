using Microsoft.EntityFrameworkCore.Migrations;

namespace MobilePhoneStore.Repository.Data.Migrations
{
    public partial class EditProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gtin",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gtin",
                table: "Products");
        }
    }
}
