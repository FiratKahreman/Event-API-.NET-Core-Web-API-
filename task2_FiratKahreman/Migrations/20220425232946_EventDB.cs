using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace task2_FiratKahreman.Migrations
{
    public partial class EventDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyRePassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RePassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOrganizer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ActivityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Limit = table.Column<int>(type: "int", nullable: false),
                    NeedTicket = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    TicketPrice = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activities_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityCompany",
                columns: table => new
                {
                    CompanyActivitiesActivityId = table.Column<int>(type: "int", nullable: false),
                    SellerCompaniesCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityCompany", x => new { x.CompanyActivitiesActivityId, x.SellerCompaniesCompanyId });
                    table.ForeignKey(
                        name: "FK_ActivityCompany_Activities_CompanyActivitiesActivityId",
                        column: x => x.CompanyActivitiesActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityCompany_Companies_SellerCompaniesCompanyId",
                        column: x => x.SellerCompaniesCompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityUser",
                columns: table => new
                {
                    AttendedActivitiesActivityId = table.Column<int>(type: "int", nullable: false),
                    AttendedUsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityUser", x => new { x.AttendedActivitiesActivityId, x.AttendedUsersUserId });
                    table.ForeignKey(
                        name: "FK_ActivityUser_Activities_AttendedActivitiesActivityId",
                        column: x => x.AttendedActivitiesActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityUser_Users_AttendedUsersUserId",
                        column: x => x.AttendedUsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CategoryId",
                table: "Activities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CityId",
                table: "Activities",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCompany_SellerCompaniesCompanyId",
                table: "ActivityCompany",
                column: "SellerCompaniesCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityUser_AttendedUsersUserId",
                table: "ActivityUser",
                column: "AttendedUsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityCompany");

            migrationBuilder.DropTable(
                name: "ActivityUser");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
