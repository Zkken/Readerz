using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Reader.Application.Common.Mappings;
using Readerz.Domain.Entities;
using Readerz.Domain.Enums;

namespace Reader.Application.CardSets.Queries.GetCardSets
{
    public class CardSetDto : IMapFrom<CardSet>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CardSetStatus Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CardSet, CardSetDto>();
        }
    }
}