using Microsoft.EntityFrameworkCore.Migrations;

namespace SibersTest.DAL.Migrations
{
    public partial class AddTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProjectLeader",
                table: "ProjectsUsers");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TaskPerfomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TaskStatus = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_TaskPerfomerId",
                        column: x => x.TaskPerfomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AuthorId",
                table: "Tasks",
                column: "AuthorId",
                unique: true,
                filter: "[AuthorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskPerfomerId",
                table: "Tasks",
                column: "TaskPerfomerId",
                unique: true,
                filter: "[TaskPerfomerId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.AddColumn<bool>(
                name: "IsProjectLeader",
                table: "ProjectsUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
