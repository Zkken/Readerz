using Microsoft.EntityFrameworkCore.Migrations;

namespace Readerz.Web.Infrastructure.Translator.Persistence.Migrations
{
    public partial class RemoveCardSetDislike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dislike",
                table: "CardSets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dislike",
                table: "CardSets",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
