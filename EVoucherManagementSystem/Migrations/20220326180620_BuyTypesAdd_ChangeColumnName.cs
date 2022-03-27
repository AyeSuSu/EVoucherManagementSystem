using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVoucherManagementSystem.Migrations
{
    public partial class BuyTypesAdd_ChangeColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_maxlimit",
                table: "BuyTypes",
                newName: "giftUser_maxlimit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "giftUser_maxlimit",
                table: "BuyTypes",
                newName: "user_maxlimit");
        }
    }
}
