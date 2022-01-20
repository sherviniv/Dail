using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dail.Infrastructure.Persistence.Migrations
{
    public partial class AddTimeSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeScheduleId",
                schema: "Dail",
                table: "ActivityTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TimeSchedules",
                schema: "Dail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSchedules", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTimes_TimeScheduleId",
                schema: "Dail",
                table: "ActivityTimes",
                column: "TimeScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityTimes_TimeSchedules_TimeScheduleId",
                schema: "Dail",
                table: "ActivityTimes",
                column: "TimeScheduleId",
                principalSchema: "Dail",
                principalTable: "TimeSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityTimes_TimeSchedules_TimeScheduleId",
                schema: "Dail",
                table: "ActivityTimes");

            migrationBuilder.DropTable(
                name: "TimeSchedules",
                schema: "Dail");

            migrationBuilder.DropIndex(
                name: "IX_ActivityTimes_TimeScheduleId",
                schema: "Dail",
                table: "ActivityTimes");

            migrationBuilder.DropColumn(
                name: "TimeScheduleId",
                schema: "Dail",
                table: "ActivityTimes");
        }
    }
}
