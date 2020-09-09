using AutoMapper;
using Readerz.Application.Common.Mappings;
using Readerz.Domain.Entities;

namespace Readerz.Application.CardSets.Queries.GetCardSets
{
    public class CardSetDto : IMapFrom<CardSet>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public int TimesPlayed { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CardSet, CardSetDto>()
                .ForMember(dto => dto.Status, options => options.MapFrom(entity => entity.Status.ToString()));
        }
    }
}