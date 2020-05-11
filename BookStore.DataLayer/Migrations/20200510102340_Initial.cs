using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.DataLayer.Migrations {
    public partial class Initial : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new {
                    id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Authors", x => x.id); });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new {
                    id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    Authorid = table.Column<string>(nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Books", x => x.id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_Authorid",
                        column: x => x.Authorid,
                        principalTable: "Authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Authorid",
                table: "Books",
                column: "Authorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}