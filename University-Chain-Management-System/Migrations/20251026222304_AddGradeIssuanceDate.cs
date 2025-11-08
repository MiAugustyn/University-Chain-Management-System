using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_Chain_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddGradeIssuanceDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "IssuanceDate",
                table: "Grades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssuanceDate",
                table: "Grades");
        }
    }
}
