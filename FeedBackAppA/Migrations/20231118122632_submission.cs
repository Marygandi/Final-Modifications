using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedBackAppA.Migrations
{
    public partial class submission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveySubmissions",
                columns: table => new
                {
                    SurveySubmissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveySubmissions", x => x.SurveySubmissionId);
                    table.ForeignKey(
                        name: "FK_SurveySubmissions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveySubmissions_Users_Username",
                        column: x => x.Username,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionResponses",
                columns: table => new
                {
                    QuestionResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    SurveySubmissionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionResponses", x => x.QuestionResponseId);
                    table.ForeignKey(
                        name: "FK_QuestionResponses_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionResponses_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionResponses_SurveySubmissions_SurveySubmissionId",
                        column: x => x.SurveySubmissionId,
                        principalTable: "SurveySubmissions",
                        principalColumn: "SurveySubmissionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_AnswerId",
                table: "QuestionResponses",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_QuestionId",
                table: "QuestionResponses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_SurveySubmissionId",
                table: "QuestionResponses",
                column: "SurveySubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveySubmissions_SurveyId",
                table: "SurveySubmissions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveySubmissions_Username",
                table: "SurveySubmissions",
                column: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionResponses");

            migrationBuilder.DropTable(
                name: "SurveySubmissions");
        }
    }
}
