using System.Collections.Generic;

namespace Reader.Application.CardSets.Queries.GetCardSets
{
    public class CardSetVm
    {
        public ICollection<CardSetDto> CardSetDtos { get; set; }
    }
}