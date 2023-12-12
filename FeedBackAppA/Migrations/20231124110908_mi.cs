using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedBackAppA.Migrations
{
    public partial class mi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SurveySubmissions_SurveyId",
                table: "SurveySubmissions");

            migrationBuilder.AddColumn<string>(
                name: "Username1",
                table: "SurveySubmissions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SurveyReports",
                columns: table => new
                {
                    SurveyId = table.Column<int>(type: "int", nullable: false),
                    SurveyTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RespondentCount = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveySubmissions_SurveyId",
                table: "SurveySubmissions",
                column: "SurveyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurveySubmissions_Username1",
                table: "SurveySubmissions",
                column: "Username1");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveySubmissions_Users_Username1",
                table: "SurveySubmissions",
                column: "Username1",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveySubmissions_Users_Username1",
                table: "SurveySubmissions");

            migrationBuilder.DropTable(
                name: "SurveyReports");

            migrationBuilder.DropIndex(
                name: "IX_SurveySubmissions_SurveyId",
                table: "SurveySubmissions");

            migrationBuilder.DropIndex(
                name: "IX_SurveySubmissions_Username1",
                table: "SurveySubmissions");

            migrationBuilder.DropColumn(
                name: "Username1",
                table: "SurveySubmissions");

            migrationBuilder.CreateIndex(
                name: "IX_SurveySubmissions_SurveyId",
                table: "SurveySubmissions",
                column: "SurveyId");
        }
    }
}
