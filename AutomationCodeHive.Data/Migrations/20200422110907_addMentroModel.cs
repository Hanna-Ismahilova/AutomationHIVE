using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomationCodeHive.Data.Migrations
{
    public partial class addMentroModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mentors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Surname = table.Column<string>(maxLength: 80, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    Phone = table.Column<string>(maxLength: 80, nullable: false),
                    Education = table.Column<int>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    User = table.Column<int>(nullable: false),
                    Technologies = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mentors");
        }
    }
}
