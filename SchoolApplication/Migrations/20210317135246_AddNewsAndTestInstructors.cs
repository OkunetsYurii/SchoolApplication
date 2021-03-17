using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApplication.Migrations
{
    public partial class AddNewsAndTestInstructors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstructorId",
                table: "Tests",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    AttachedLink = table.Column<string>(nullable: true),
                    AttachedLinkName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "47b1ed1c-ef1b-4c20-b307-0245cfe91ab8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaf7b189-75ba-47b7-862f-9c31da2b313c",
                column: "ConcurrencyStamp",
                value: "c7870970-96ef-4513-b0eb-739c2ad6dd64");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "98549d90-be74-4c7e-b660-8420b3d787ba", "AQAAAAEAACcQAAAAEJgUJC4pXd33mmXQzcGYfILMeVM0oTc85OClAOooDCaybK2EOjPomZpg1Ir+j+oOwA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_InstructorId",
                table: "Tests",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_InstructorId",
                table: "Tests",
                column: "InstructorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_InstructorId",
                table: "Tests");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropIndex(
                name: "IX_Tests_InstructorId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Tests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "d121922e-d8bd-4861-861b-387d186adf22");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaf7b189-75ba-47b7-862f-9c31da2b313c",
                column: "ConcurrencyStamp",
                value: "6b21af4c-82e7-434d-90d8-fd740d1fd936");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17014e2f-f608-4bf4-bf7f-2c158998bf6f", "AQAAAAEAACcQAAAAELox6Roy8ddZahjJly4gr/XTQqTnQtVbxMhdQj2NjHYm5PO/jjmf3ndPE9nEE+hKQw==" });
        }
    }
}
