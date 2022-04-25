using Microsoft.EntityFrameworkCore.Migrations;

namespace task2_FiratKahreman.Migrations
{
    public partial class event2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityCompany_Companies_CompaniesCompanyId",
                table: "ActivityCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityUser_Activities_ActivitiesActivityId",
                table: "ActivityUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityUser_Users_ActivitiesUsersUserId",
                table: "ActivityUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityCompany",
                table: "ActivityCompany");

            migrationBuilder.DropIndex(
                name: "IX_ActivityCompany_CompanyActivitiesActivityId",
                table: "ActivityCompany");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ActivitiesUsersUserId",
                table: "ActivityUser",
                newName: "AttendedUsersUserId");

            migrationBuilder.RenameColumn(
                name: "ActivitiesActivityId",
                table: "ActivityUser",
                newName: "AttendedActivitiesActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityUser_ActivitiesUsersUserId",
                table: "ActivityUser",
                newName: "IX_ActivityUser_AttendedUsersUserId");

            migrationBuilder.RenameColumn(
                name: "CompaniesCompanyId",
                table: "ActivityCompany",
                newName: "SellerCompaniesCompanyId");

            migrationBuilder.AddColumn<bool>(
                name: "IsOrganizer",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyMail",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyPassword",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyRePassword",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Booked",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityCompany",
                table: "ActivityCompany",
                columns: new[] { "CompanyActivitiesActivityId", "SellerCompaniesCompanyId" });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCompany_SellerCompaniesCompanyId",
                table: "ActivityCompany",
                column: "SellerCompaniesCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityCompany_Companies_SellerCompaniesCompanyId",
                table: "ActivityCompany",
                column: "SellerCompaniesCompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityUser_Activities_AttendedActivitiesActivityId",
                table: "ActivityUser",
                column: "AttendedActivitiesActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityUser_Users_AttendedUsersUserId",
                table: "ActivityUser",
                column: "AttendedUsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityCompany_Companies_SellerCompaniesCompanyId",
                table: "ActivityCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityUser_Activities_AttendedActivitiesActivityId",
                table: "ActivityUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityUser_Users_AttendedUsersUserId",
                table: "ActivityUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityCompany",
                table: "ActivityCompany");

            migrationBuilder.DropIndex(
                name: "IX_ActivityCompany_SellerCompaniesCompanyId",
                table: "ActivityCompany");

            migrationBuilder.DropColumn(
                name: "IsOrganizer",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyMail",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyPassword",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyRePassword",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Booked",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "AttendedUsersUserId",
                table: "ActivityUser",
                newName: "ActivitiesUsersUserId");

            migrationBuilder.RenameColumn(
                name: "AttendedActivitiesActivityId",
                table: "ActivityUser",
                newName: "ActivitiesActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityUser_AttendedUsersUserId",
                table: "ActivityUser",
                newName: "IX_ActivityUser_ActivitiesUsersUserId");

            migrationBuilder.RenameColumn(
                name: "SellerCompaniesCompanyId",
                table: "ActivityCompany",
                newName: "CompaniesCompanyId");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityCompany",
                table: "ActivityCompany",
                columns: new[] { "CompaniesCompanyId", "CompanyActivitiesActivityId" });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCompany_CompanyActivitiesActivityId",
                table: "ActivityCompany",
                column: "CompanyActivitiesActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityCompany_Companies_CompaniesCompanyId",
                table: "ActivityCompany",
                column: "CompaniesCompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityUser_Activities_ActivitiesActivityId",
                table: "ActivityUser",
                column: "ActivitiesActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityUser_Users_ActivitiesUsersUserId",
                table: "ActivityUser",
                column: "ActivitiesUsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
