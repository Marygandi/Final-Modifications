using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedBackAppA.Migrations
{
    public partial class n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SurveySubmissions_SurveyId",
                table: "SurveySubmissions");

            migrationBuilder.CreateIndex(
                name: "IX_SurveySubmissions_SurveyId",
                table: "SurveySubmissions",
                column: "SurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SurveySubmissions_SurveyId",
                table: "SurveySubmissions");

            migrationBuilder.CreateIndex(
                name: "IX_SurveySubmissions_SurveyId",
                table: "SurveySubmissions",
                column: "SurveyId",
                unique: true);
        }
    }
}
