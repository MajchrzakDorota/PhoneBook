using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBook.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getutcdate()"),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { 1, "Family" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { 2, "Friends" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "GroupName" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "GroupId", "MobileNumber", "Name" },
                values: new object[] { 1, 1, "236448569", "Mother" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "GroupId", "MobileNumber", "Name" },
                values: new object[] { 2, 1, "856994785", "Dad" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "GroupId", "MobileNumber", "Name" },
                values: new object[] { 3, 2, "741002569", "John" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_GroupId",
                table: "Contacts",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
