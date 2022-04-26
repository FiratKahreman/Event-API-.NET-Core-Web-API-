using Microsoft.EntityFrameworkCore.Migrations;

namespace task2_FiratKahreman.Migrations
{
    public partial class EventDBv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Categories_CategoryId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Cities_CityId",
                table: "Activities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CategoryId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CityId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Cities",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Activities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "Activities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "CityName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CategoryName",
                table: "Activities",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CityName",
                table: "Activities",
                column: "CityName");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Categories_CategoryName",
                table: "Activities",
                column: "CategoryName",
                principalTable: "Categories",
                principalColumn: "CategoryName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Cities_CityName",
                table: "Activities",
                column: "CityName",
                principalTable: "Cities",
                principalColumn: "CityName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Categories_CategoryName",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Cities_CityName",
                table: "Activities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CategoryName",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CityName",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CategoryId",
                table: "Activities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CityId",
                table: "Activities",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Categories_CategoryId",
                table: "Activities",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Cities_CityId",
                table: "Activities",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
