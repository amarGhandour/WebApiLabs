using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiLabs.Migrations
{
    public partial class topics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_Topic_TopicId",
                table: "courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topic",
                table: "Topic");

            migrationBuilder.RenameTable(
                name: "Topic",
                newName: "topics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_topics",
                table: "topics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_topics_TopicId",
                table: "courses",
                column: "TopicId",
                principalTable: "topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_topics_TopicId",
                table: "courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_topics",
                table: "topics");

            migrationBuilder.RenameTable(
                name: "topics",
                newName: "Topic");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topic",
                table: "Topic",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_Topic_TopicId",
                table: "courses",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
