using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVoucherManagementSystem.Migrations
{
    public partial class ItemPurchaseAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemPurchase",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(37)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    item = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    promocode = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    totalamount = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPurchase", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPurchase");
        }
    }
}
