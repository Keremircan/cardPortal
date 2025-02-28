using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cardPortal.Migrations
{
    /// <inheritdoc />
    public partial class SeventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "Changes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Changes_CompanyID",
                table: "Changes",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_Companies_CompanyID",
                table: "Changes",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Changes_Companies_CompanyID",
                table: "Changes");

            migrationBuilder.DropIndex(
                name: "IX_Changes_CompanyID",
                table: "Changes");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Changes");
        }
    }
}
