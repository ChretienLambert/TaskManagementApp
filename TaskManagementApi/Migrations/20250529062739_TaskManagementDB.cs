using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class TaskManagementDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Users_UserName2",
                table: "Schools");

            migrationBuilder.RenameColumn(
                name: "UserName2",
                table: "Schools",
                newName: "UserName");

            migrationBuilder.RenameIndex(
                name: "IX_Schools_UserName2",
                table: "Schools",
                newName: "IX_Schools_UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Users_UserName",
                table: "Schools",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Users_UserName",
                table: "Schools");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Schools",
                newName: "UserName2");

            migrationBuilder.RenameIndex(
                name: "IX_Schools_UserName",
                table: "Schools",
                newName: "IX_Schools_UserName2");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Users_UserName2",
                table: "Schools",
                column: "UserName2",
                principalTable: "Users",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
