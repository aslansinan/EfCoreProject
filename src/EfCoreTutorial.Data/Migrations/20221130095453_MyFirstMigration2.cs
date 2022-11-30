using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreTutorial.Data.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "birth_date",
                schema: "dbo",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "first_name",
                schema: "dbo",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "nuber",
                schema: "dbo",
                table: "courses");

            migrationBuilder.RenameColumn(
                name: "last_name",
                schema: "dbo",
                table: "courses",
                newName: "name");

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                schema: "dbo",
                table: "courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "students",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(name: "first_name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    nuber = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    birthdate = table.Column<DateTime>(name: "birth_date", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(name: "first_name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    birthdate = table.Column<DateTime>(name: "birth_date", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "teachers",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "is_active",
                schema: "dbo",
                table: "courses");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "dbo",
                table: "courses",
                newName: "last_name");

            migrationBuilder.AddColumn<DateTime>(
                name: "birth_date",
                schema: "dbo",
                table: "courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                schema: "dbo",
                table: "courses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "nuber",
                schema: "dbo",
                table: "courses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
