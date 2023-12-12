using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedBackAppA.Migrations
{
    public partial class sub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResponses_Answers_AnswerId",
                table: "QuestionResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResponses_Questions_QuestionId",
                table: "QuestionResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveySubmissions_Surveys_SurveyId",
                table: "SurveySubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveySubmissions_Users_Username",
                table: "SurveySubmissions");

            migrationBuilder.DropIndex(
                name: "IX_SurveySubmissions_SurveyId",
                table: "SurveySubmissions");

            migrationBuilder.DropIndex(
                name: "IX_SurveySubmissions_Username",
                table: "SurveySubmissions");

            migrationBuilder.DropIndex(
                name: "IX_QuestionResponses_AnswerId",
                table: "QuestionResponses");

            migrationBuilder.DropIndex(
                name: "IX_QuestionResponses_QuestionId",
                table: "QuestionResponses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SurveySubmissions");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "SurveySubmissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "SurveySubmissions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "SurveySubmissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SurveySubmissions_SurveyId",
                table: "SurveySubmissions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveySubmissions_Username",
                table: "SurveySubmissions",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_AnswerId",
                table: "QuestionResponses",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_QuestionId",
                table: "QuestionResponses",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResponses_Answers_AnswerId",
                table: "QuestionResponses",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResponses_Questions_QuestionId",
                table: "QuestionResponses",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveySubmissions_Surveys_SurveyId",
                table: "SurveySubmissions",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveySubmissions_Users_Username",
                table: "SurveySubmissions",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
