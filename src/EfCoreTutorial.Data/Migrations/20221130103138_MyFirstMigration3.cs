using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreTutorial.Data.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student_adresses",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    district = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    fulladress = table.Column<string>(name: "full_adress", type: "nvarchar(150)", maxLength: 150, nullable: false),
                    country = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    studentid = table.Column<int>(name: "student_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_adresses", x => x.id);
                    table.ForeignKey(
                        name: "student_address_id_fk",
                        column: x => x.studentid,
                        principalSchema: "dbo",
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_student_adresses_student_id",
                schema: "dbo",
                table: "student_adresses",
                column: "student_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student_adresses",
                schema: "dbo");
        }
    }
}
