using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class minh71 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "LastOnline",
                table: "User",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "TopicProgress",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Subject",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "BoughtSubject",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastOnline",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "TopicProgress");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "BoughtSubject");
        }
    }
}
