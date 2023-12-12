using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedBackAppA.Migrations
{
    public partial class r : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResponseCount",
                table: "Surveys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SurveySubmissions_SurveyId",
                table: "SurveySubmissions",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveySubmissions_Surveys_SurveyId",
                table: "SurveySubmissions",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveySubmissions_Surveys_SurveyId",
                table: "SurveySubmissions");

            migrationBuilder.DropIndex(
                name: "IX_SurveySubmissions_SurveyId",
                table: "SurveySubmissions");

            migrationBuilder.DropColumn(
                name: "ResponseCount",
                table: "Surveys");
        }
    }
}
