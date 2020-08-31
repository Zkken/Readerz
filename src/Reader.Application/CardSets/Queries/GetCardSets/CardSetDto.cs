using AutoMapper;
using Reader.Application.Common.Mappings;
using Readerz.Web.Domain.Entities;

namespace Reader.Application.CardSets.Queries.GetCardSets
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