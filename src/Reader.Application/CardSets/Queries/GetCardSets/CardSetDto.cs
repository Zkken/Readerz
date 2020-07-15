using Readerz.Domain.Enums;

namespace Reader.Application.CardSets.Queries.GetCardSets
{
    public class CardSetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CardSetStatus Status { get; set; }
        
    }
}