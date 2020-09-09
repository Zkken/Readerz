using AutoMapper;
using Readerz.Application.Common.Mappings;
using Readerz.Domain.Entities;

namespace Readerz.Application.CardSets.Queries.GetCardSetDetail
{
    public class CardDto : IMapFrom<Card>
    {
        public int Id { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Card, CardDto>();
        }
    }
}