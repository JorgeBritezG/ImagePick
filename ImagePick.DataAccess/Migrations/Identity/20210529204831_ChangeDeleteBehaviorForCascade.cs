using Microsoft.EntityFrameworkCore.Migrations;

namespace ImagePick.DataAccess.Migrations.Identity
{
    public partial class ChangeDeleteBehaviorForCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_AspNetUsers_UserId",
                table: "Album");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_AspNetUsers_UserId",
                table: "Album",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_AspNetUsers_UserId",
                table: "Album");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_AspNetUsers_UserId",
                table: "Album",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
