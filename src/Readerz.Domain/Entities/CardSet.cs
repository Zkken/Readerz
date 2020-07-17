using Readerz.Domain.Common;
using Readerz.Domain.Enums;
using System.Collections.Generic;

namespace Readerz.Domain.Entities
{
    public class CardSet : AuditableEntity
    {
        public CardSet()
        {
            Cards = new HashSet<Card>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public CardSetStatus Status { get; set; }
        public int? TextId { get; set; }
        public int CardCreatorId { get; set; }
        public ICollection<Card> Cards { get; set; }
        public Text Text { get; set; }
        public CardCreator CardCreator { get; set; }
    }
}
