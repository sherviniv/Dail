using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dail.Infrastructure.Persistence.Migrations
{
    public partial class AddActivityTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                schema: "Dail",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "EndTime",
                schema: "Dail",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "StartTime",
                schema: "Dail",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Dail",
                table: "Activities",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ActivityTimeId",
                schema: "Dail",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActivityTimes",
                schema: "Dail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTimes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityTimeId",
                schema: "Dail",
                table: "Activities",
                column: "ActivityTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityTimes_ActivityTimeId",
                schema: "Dail",
                table: "Activities",
                column: "ActivityTimeId",
                principalSchema: "Dail",
                principalTable: "ActivityTimes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ActivityTimes_ActivityTimeId",
                schema: "Dail",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "ActivityTimes",
                schema: "Dail");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ActivityTimeId",
                schema: "Dail",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityTimeId",
                schema: "Dail",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "Dail",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<int>(
                name: "Day",
                schema: "Dail",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                schema: "Dail",
                table: "Activities",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                schema: "Dail",
                table: "Activities",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");
        }
    }
}
