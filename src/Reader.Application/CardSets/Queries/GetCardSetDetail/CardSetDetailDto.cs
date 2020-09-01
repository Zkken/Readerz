using System.Collections.Generic;
using AutoMapper;
using Reader.Application.CardSets.Queries.GetCardSets;
using Reader.Application.Common.Mappings;
using Readerz.Domain.Entities;

namespace Reader.Application.CardSets.Queries.GetCardSetDetail
{
    public class CardSetDetailDto : IMapFrom<CardSet>
    {
        public CardSetDetailDto()
        {
            Cards = new List<CardDto>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public int TimesPlayed { get; set; }
        public List<CardDto> Cards { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CardSet, CardSetDetailDto>()
                .ForMember(dto => dto.Status, options => options.MapFrom(entity => entity.Status.ToString()))
                .ForMember(dto => dto.Cards, options => options.Ignore());
        }
    }
}