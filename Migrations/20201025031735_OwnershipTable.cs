using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace geo_auth_data.Migrations
{
    public partial class OwnershipTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userinroles_roles_RoleId",
                table: "userinroles");

            migrationBuilder.DropForeignKey(
                name: "FK_userinroles_users_UserId",
                table: "userinroles");

            migrationBuilder.DropForeignKey(
                name: "FK_users_owners_OwnerId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_owners",
                table: "owners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userinroles",
                table: "userinroles");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "owners",
                newName: "Owners");

            migrationBuilder.RenameTable(
                name: "userinroles",
                newName: "UsersInRoles");

            migrationBuilder.RenameIndex(
                name: "IX_users_OwnerId_UserName",
                table: "Users",
                newName: "IX_Users_OwnerId_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_users_OwnerId",
                table: "Users",
                newName: "IX_Users_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_userinroles_UserId",
                table: "UsersInRoles",
                newName: "IX_UsersInRoles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_userinroles_RoleId",
                table: "UsersInRoles",
                newName: "IX_UsersInRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInRoles",
                table: "UsersInRoles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UsersInOwners",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersInOwners_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersInOwners_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersInOwners_OwnerId",
                table: "UsersInOwners",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInOwners_UserId",
                table: "UsersInOwners",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Owners_OwnerId",
                table: "Users",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInRoles_Roles_RoleId",
                table: "UsersInRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInRoles_Users_UserId",
                table: "UsersInRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Owners_OwnerId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInRoles_Roles_RoleId",
                table: "UsersInRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInRoles_Users_UserId",
                table: "UsersInRoles");

            migrationBuilder.DropTable(
                name: "UsersInOwners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owners",
                table: "Owners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInRoles",
                table: "UsersInRoles");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "Owners",
                newName: "owners");

            migrationBuilder.RenameTable(
                name: "UsersInRoles",
                newName: "userinroles");

            migrationBuilder.RenameIndex(
                name: "IX_Users_OwnerId_UserName",
                table: "users",
                newName: "IX_users_OwnerId_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_Users_OwnerId",
                table: "users",
                newName: "IX_users_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInRoles_UserId",
                table: "userinroles",
                newName: "IX_userinroles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInRoles_RoleId",
                table: "userinroles",
                newName: "IX_userinroles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_owners",
                table: "owners",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userinroles",
                table: "userinroles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userinroles_roles_RoleId",
                table: "userinroles",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userinroles_users_UserId",
                table: "userinroles",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_owners_OwnerId",
                table: "users",
                column: "OwnerId",
                principalTable: "owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
