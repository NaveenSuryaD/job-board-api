using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoardApi.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobposts_JobpostId",
                table: "Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobposts",
                table: "Jobposts");

            migrationBuilder.RenameTable(
                name: "Jobposts",
                newName: "JobPosts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPosts",
                table: "JobPosts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_JobPosts_JobpostId",
                table: "Applications",
                column: "JobpostId",
                principalTable: "JobPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_JobPosts_JobpostId",
                table: "Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPosts",
                table: "JobPosts");

            migrationBuilder.RenameTable(
                name: "JobPosts",
                newName: "Jobposts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobposts",
                table: "Jobposts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobposts_JobpostId",
                table: "Applications",
                column: "JobpostId",
                principalTable: "Jobposts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
