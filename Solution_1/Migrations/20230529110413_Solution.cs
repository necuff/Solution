using Microsoft.EntityFrameworkCore.Migrations;

namespace Solution_1.Migrations
{
    public partial class Solution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Solution",
                table: "Problems");

            migrationBuilder.AddColumn<long>(
                name: "SolutionId",
                table: "Problems",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Problems_SolutionId",
                table: "Problems",
                column: "SolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_Solutions_SolutionId",
                table: "Problems",
                column: "SolutionId",
                principalTable: "Solutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_Solutions_SolutionId",
                table: "Problems");

            migrationBuilder.DropTable(
                name: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Problems_SolutionId",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "SolutionId",
                table: "Problems");

            migrationBuilder.AddColumn<string>(
                name: "Solution",
                table: "Problems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
