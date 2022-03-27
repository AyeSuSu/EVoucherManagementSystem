using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVoucherManagementSystem.Migrations
{
    public partial class PurchaseEVoucherAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseEVouchers",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(37)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    eVoucher_id = table.Column<string>(type: "char(37)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    buyType_id = table.Column<string>(type: "char(37)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    paymentMethod_id = table.Column<string>(type: "char(37)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    netAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    promoCode = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isUsed = table.Column<int>(type: "int", nullable: false),
                    createdDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updatedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseEVouchers", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseEVouchers");
        }
    }
}
