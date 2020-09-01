using Reader.Application.Common.Mappings;
using Readerz.Web.Domain.Entities;

namespace Reader.Application.CardSets.Queries.GetCardSetDetail
{
    public class CardDto : IMapFrom<Card>
    {
        public int Id { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
    }
}