using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVoucherManagementSystem.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(37)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    phoneNo = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    createdDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
