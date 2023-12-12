using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedBackAppA.Migrations
{
    public partial class mii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveySubmissions_Users_Username1",
                table: "SurveySubmissions");

            migrationBuilder.DropIndex(
                name: "IX_SurveySubmissions_Username1",
                table: "SurveySubmissions");

            migrationBuilder.DropColumn(
                name: "Username1",
                table: "SurveySubmissions");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "SurveySubmissions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_SurveySubmissions_Username",
                table: "SurveySubmissions",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveySubmissions_Users_Username",
                table: "SurveySubmissions",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveySubmissions_Users_Username",
                table: "SurveySubmissions");

            migrationBuilder.DropIndex(
                name: "IX_SurveySubmissions_Username",
                table: "SurveySubmissions");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "SurveySubmissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Username1",
                table: "SurveySubmissions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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
    }
}
