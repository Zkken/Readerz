using MediatR;
using Reader.Application.Common.Models;

namespace Reader.Application.CardSets.Queries.GetCardSets
{
    public class GetCardSetsQuery : IRequest<PaginatorResult<CardSetDto>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public bool ByCurrentUser { get; set; }
    }
}