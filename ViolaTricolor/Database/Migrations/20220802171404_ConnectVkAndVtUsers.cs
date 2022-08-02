using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViolaTricolor.Database.Migrations
{
    /// <inheritdoc cref="Migration"/>
    public partial class ConnectVkAndVtUsers : Migration
    {
        /// <inheritdoc/>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VkUsers");

            migrationBuilder.DropIndex(
                name: "IX_users_Login",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "vtusers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vtusers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VTUserVkUser",
                columns: table => new
                {
                    VTUsersId = table.Column<int>(type: "INTEGER", nullable: false),
                    VkUsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VTUserVkUser", x => new { x.VTUsersId, x.VkUsersId });
                    table.ForeignKey(
                        name: "FK_VTUserVkUser_users_VkUsersId",
                        column: x => x.VkUsersId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VTUserVkUser_vtusers_VTUsersId",
                        column: x => x.VTUsersId,
                        principalTable: "vtusers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vtusers_Login",
                table: "vtusers",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VTUserVkUser_VkUsersId",
                table: "VTUserVkUser",
                column: "VkUsersId");
        }

        /// <inheritdoc/>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VTUserVkUser");

            migrationBuilder.DropTable(
                name: "vtusers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "users",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "VkUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VkUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_Login",
                table: "users",
                column: "Login",
                unique: true);
        }
    }
}
