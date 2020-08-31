using Microsoft.EntityFrameworkCore.Migrations;

namespace Readerz.Web.Infrastructure.Translator.Persistence.Migrations
{
    public partial class CardSetTimesPlayed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimesPlayed",
                table: "CardSets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimesPlayed",
                table: "CardSets");
        }
    }
}
