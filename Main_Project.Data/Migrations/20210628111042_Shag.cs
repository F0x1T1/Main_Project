using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Main_Project.Data.Migrations
{
    public partial class Shag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CoursesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCourses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "Price(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CoursesID);
                });

            migrationBuilder.CreateTable(
                name: "FormaNavch",
                columns: table => new
                {
                    StudID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Form = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaNavch", x => x.StudID);
                });

            migrationBuilder.CreateTable(
                name: "Napryam",
                columns: table => new
                {
                    NapryamID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Predmetna_obl = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Napryam", x => x.NapryamID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false),
                    Teachingtype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormaNavchID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudID);
                    table.ForeignKey(
                        name: "FK_Student_FormaNavch_FormaNavchID",
                        column: x => x.FormaNavchID,
                        principalTable: "FormaNavch",
                        principalColumn: "StudID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vikladach",
                columns: table => new
                {
                    VikladachID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NapryamID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Nomer = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    FormaNavchStudID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vikladach", x => x.VikladachID);
                    table.ForeignKey(
                        name: "FK_Vikladach_FormaNavch_FormaNavchStudID",
                        column: x => x.FormaNavchStudID,
                        principalTable: "FormaNavch",
                        principalColumn: "StudID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vikladach_Napryam_NapryamID",
                        column: x => x.NapryamID,
                        principalTable: "Napryam",
                        principalColumn: "NapryamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudCourses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CoursesID = table.Column<int>(type: "int", nullable: false),
                    Grades = table.Column<int>(type: "int", nullable: false, defaultValue: 3),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudCourses", x => new { x.CoursesID, x.Id });
                    table.ForeignKey(
                        name: "FK_StudCourses_Courses_CoursesID",
                        column: x => x.CoursesID,
                        principalTable: "Courses",
                        principalColumn: "CoursesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudCourses_Student_Id",
                        column: x => x.Id,
                        principalTable: "Student",
                        principalColumn: "StudID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursesVikladach",
                columns: table => new
                {
                    CoursesID = table.Column<int>(type: "int", nullable: false),
                    TeachersVikladachID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesVikladach", x => new { x.CoursesID, x.TeachersVikladachID });
                    table.ForeignKey(
                        name: "FK_CoursesVikladach_Courses_CoursesID",
                        column: x => x.CoursesID,
                        principalTable: "Courses",
                        principalColumn: "CoursesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesVikladach_Vikladach_TeachersVikladachID",
                        column: x => x.TeachersVikladachID,
                        principalTable: "Vikladach",
                        principalColumn: "VikladachID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesVikladach_TeachersVikladachID",
                table: "CoursesVikladach",
                column: "TeachersVikladachID");

            migrationBuilder.CreateIndex(
                name: "IX_StudCourses_Id",
                table: "StudCourses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_FormaNavchID",
                table: "Student",
                column: "FormaNavchID");

            migrationBuilder.CreateIndex(
                name: "IX_Vikladach_FormaNavchStudID",
                table: "Vikladach",
                column: "FormaNavchStudID");

            migrationBuilder.CreateIndex(
                name: "IX_Vikladach_NapryamID",
                table: "Vikladach",
                column: "NapryamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesVikladach");

            migrationBuilder.DropTable(
                name: "StudCourses");

            migrationBuilder.DropTable(
                name: "Vikladach");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Napryam");

            migrationBuilder.DropTable(
                name: "FormaNavch");
        }
    }
}
