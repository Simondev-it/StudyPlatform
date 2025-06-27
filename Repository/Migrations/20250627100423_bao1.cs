using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class bao1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Following_User_FollowingNavigationId",
                table: "Following");

            migrationBuilder.DropIndex(
                name: "IX_Following_FollowingNavigationId",
                table: "Following");

            migrationBuilder.DropColumn(
                name: "FollowingNavigationId",
                table: "Following");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Question",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FollowingNavigationId",
                table: "Following",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Following_FollowingNavigationId",
                table: "Following",
                column: "FollowingNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Following_User_FollowingNavigationId",
                table: "Following",
                column: "FollowingNavigationId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
