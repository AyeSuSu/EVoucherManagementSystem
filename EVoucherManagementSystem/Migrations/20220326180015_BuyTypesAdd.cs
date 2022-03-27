using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVoucherManagementSystem.Migrations
{
    public partial class BuyTypesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyTypes",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(37)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isMyself = table.Column<int>(type: "int", nullable: false),
                    isGiftOthers = table.Column<int>(type: "int", nullable: false),
                    eVoucher_maxlimit = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    user_maxlimit = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    createdDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyTypes", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyTypes");
        }
    }
}
