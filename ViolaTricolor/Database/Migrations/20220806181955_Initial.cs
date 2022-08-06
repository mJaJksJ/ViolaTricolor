using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViolaTricolor.Database.Migrations
{
    /// <inheritdoc cref="Migration"/>
    public partial class Initial : Migration
    {
        /// <inheritdoc/>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FriendsJournal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WhoId = table.Column<long>(type: "INTEGER", nullable: false),
                    WhomId = table.Column<long>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RelationsStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendsJournal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VkFriends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstFriendId = table.Column<long>(type: "INTEGER", nullable: false),
                    SecondFriendId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VkFriends", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VkUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    VtUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VkUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VTUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    VkUserId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VTUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VTUsers_VkUsers_VkUserId",
                        column: x => x.VkUserId,
                        principalTable: "VkUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VTUserVkUser",
                columns: table => new
                {
                    ObservableVkUsersId = table.Column<long>(type: "INTEGER", nullable: false),
                    ObserverVTUsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VTUserVkUser", x => new { x.ObservableVkUsersId, x.ObserverVTUsersId });
                    table.ForeignKey(
                        name: "FK_VTUserVkUser_VkUsers_ObservableVkUsersId",
                        column: x => x.ObservableVkUsersId,
                        principalTable: "VkUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VTUserVkUser_VTUsers_ObserverVTUsersId",
                        column: x => x.ObserverVTUsersId,
                        principalTable: "VTUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendsJournal_WhoId",
                table: "FriendsJournal",
                column: "WhoId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendsJournal_WhomId",
                table: "FriendsJournal",
                column: "WhomId");

            migrationBuilder.CreateIndex(
                name: "IX_VkFriends_FirstFriendId",
                table: "VkFriends",
                column: "FirstFriendId");

            migrationBuilder.CreateIndex(
                name: "IX_VkFriends_SecondFriendId",
                table: "VkFriends",
                column: "SecondFriendId");

            migrationBuilder.CreateIndex(
                name: "IX_VkUsers_VtUserId",
                table: "VkUsers",
                column: "VtUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VTUsers_Login",
                table: "VTUsers",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VTUsers_VkUserId",
                table: "VTUsers",
                column: "VkUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VTUserVkUser_ObserverVTUsersId",
                table: "VTUserVkUser",
                column: "ObserverVTUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendsJournal_VkUsers_WhoId",
                table: "FriendsJournal",
                column: "WhoId",
                principalTable: "VkUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendsJournal_VkUsers_WhomId",
                table: "FriendsJournal",
                column: "WhomId",
                principalTable: "VkUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VkFriends_VkUsers_FirstFriendId",
                table: "VkFriends",
                column: "FirstFriendId",
                principalTable: "VkUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VkFriends_VkUsers_SecondFriendId",
                table: "VkFriends",
                column: "SecondFriendId",
                principalTable: "VkUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VkUsers_VTUsers_VtUserId",
                table: "VkUsers",
                column: "VtUserId",
                principalTable: "VTUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc/>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VTUsers_VkUsers_VkUserId",
                table: "VTUsers");

            migrationBuilder.DropTable(
                name: "FriendsJournal");

            migrationBuilder.DropTable(
                name: "VkFriends");

            migrationBuilder.DropTable(
                name: "VTUserVkUser");

            migrationBuilder.DropTable(
                name: "VkUsers");

            migrationBuilder.DropTable(
                name: "VTUsers");
        }
    }
}
