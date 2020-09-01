using Readerz.Web.Domain.Common;

namespace Readerz.Domain.Entities
{
    public class Card : AuditableEntity
    {
        public int Id { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }

        public int CardSetId { get; set; }
        public CardSet CardSet { get; set; }
    }
}
