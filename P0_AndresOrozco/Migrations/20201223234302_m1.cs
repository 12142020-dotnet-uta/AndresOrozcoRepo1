using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P0_AndresOrozco.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "customers");

            migrationBuilder.CreateTable(
                name: "guids",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guids", x => x.CustomerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guids");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
