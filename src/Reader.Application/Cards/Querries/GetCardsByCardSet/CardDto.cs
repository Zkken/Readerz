using Reader.Application.Common.Mappings;
using Readerz.Domain.Entities;

namespace Reader.Application.Cards.Queries.GetCardsByCardSet
{
    public abstract class CardDto : IMapFrom<Card>
    {
        public int Id { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }

    }
}
