using System.Collections.Generic;
using Readerz.Web.Domain.Common;
using Readerz.Web.Domain.Enums;

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
        public int Like { get; set; }
        public int Dislike { get; set; }
        public int TimesPlayed { get; set; }
        public CardSetStatus Status { get; set; }
        public int? TextId { get; set; }
        public ICollection<Card> Cards { get; set; }
        public Text Text { get; set; }
    }
}
