using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBookWebApp.Migrations
{
    /// <inheritdoc />
    public partial class RemovedConnections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_LoginData_LoginDataLoginId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_UserData_UserDataUserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserData_LoginData_LoginDataLoginId",
                table: "UserData");

            migrationBuilder.DropTable(
                name: "LoginData");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_LoginDataLoginId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserDataUserId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserData",
                table: "UserData");

            migrationBuilder.DropIndex(
                name: "IX_UserData_LoginDataLoginId",
                table: "UserData");

            migrationBuilder.DropColumn(
                name: "LoginDataLoginId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserDataUserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "LoginDataLoginId",
                table: "UserData");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "UserData");

            migrationBuilder.RenameTable(
                name: "UserData",
                newName: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tasks",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Duration",
                table: "Tasks",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedTo",
                table: "Tasks",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedBy",
                table: "Tasks",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserData");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Tasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedTo",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "AssignedBy",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "LoginDataLoginId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDataUserId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserData",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "LoginDataLoginId",
                table: "UserData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoginId",
                table: "UserData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserData",
                table: "UserData",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "LoginData",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNmae = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginData", x => x.LoginId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_LoginDataLoginId",
                table: "Tasks",
                column: "LoginDataLoginId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserDataUserId",
                table: "Tasks",
                column: "UserDataUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserData_LoginDataLoginId",
                table: "UserData",
                column: "LoginDataLoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_LoginData_LoginDataLoginId",
                table: "Tasks",
                column: "LoginDataLoginId",
                principalTable: "LoginData",
                principalColumn: "LoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_UserData_UserDataUserId",
                table: "Tasks",
                column: "UserDataUserId",
                principalTable: "UserData",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_LoginData_LoginDataLoginId",
                table: "UserData",
                column: "LoginDataLoginId",
                principalTable: "LoginData",
                principalColumn: "LoginId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
