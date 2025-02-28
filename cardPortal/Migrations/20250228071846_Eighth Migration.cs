using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cardPortal.Migrations
{
    /// <inheritdoc />
    public partial class EighthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Changes_Companies_CompanyID",
                table: "Changes");

            migrationBuilder.DropIndex(
                name: "IX_Changes_CompanyID",
                table: "Changes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Changes_CompanyID",
                table: "Changes",
                column: "CompanyID");

            
        }
    }
}
