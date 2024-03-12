using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContentManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectAndUserStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password_Salt",
                schema: "User",
                table: "User");

            migrationBuilder.EnsureSchema(
                name: "Project");

            migrationBuilder.RenameColumn(
                name: "Password_Value",
                schema: "User",
                table: "User",
                newName: "Password");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "User",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPermission",
                schema: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPermission", x => new { x.ProjectId, x.Id });
                    table.ForeignKey(
                        name: "FK_ProjectPermission_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "Project",
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectPermission",
                schema: "Project");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "Project");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "User",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Password",
                schema: "User",
                table: "User",
                newName: "Password_Value");

            migrationBuilder.AddColumn<Guid>(
                name: "Password_Salt",
                schema: "User",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
