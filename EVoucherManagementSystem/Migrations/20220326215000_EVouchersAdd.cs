using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVoucherManagementSystem.Migrations
{
    public partial class EVouchersAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EVouchers",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(37)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    expiryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    image = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<string>(type: "char(37)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    phoneNo = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    qrCode = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    createdDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVouchers", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EVouchers");
        }
    }
}
