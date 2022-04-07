using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_blogger_blog_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BloggerID",
                table: "Blogs",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BloggerID",
                table: "Blogs",
                column: "BloggerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Bloggers_BloggerID",
                table: "Blogs",
                column: "BloggerID",
                principalTable: "Bloggers",
                principalColumn: "BloggerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Bloggers_BloggerID",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_BloggerID",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BloggerID",
                table: "Blogs");
        }
    }
}
