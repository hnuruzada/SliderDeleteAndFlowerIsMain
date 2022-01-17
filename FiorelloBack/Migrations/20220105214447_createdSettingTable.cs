using Microsoft.EntityFrameworkCore.Migrations;

namespace FiorelloBack.Migrations
{
    public partial class createdSettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(maxLength: 100, nullable: true),
                    SearchIcon = table.Column<string>(maxLength: 100, nullable: true),
                    BasketIcon = table.Column<string>(maxLength: 100, nullable: true),
                    ParallaxImage = table.Column<string>(maxLength: 100, nullable: true),
                    InstagramUrl = table.Column<string>(maxLength: 150, nullable: true),
                    FbUrl = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "settings");
        }
    }
}
