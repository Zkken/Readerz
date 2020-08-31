using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Reader.Application.Common.Exceptions;
using Reader.Application.Common.Interfaces;
using Reader.Application.Common.Models;
using Readerz.Web.Domain.Entities;
using Readerz.Web.Domain.Enums;

namespace Reader.Application.CardSets.Queries.GetCardSets
{
    public class GetCardSetsQuery : IRequest<PaginatorResult<CardSetDto>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public bool ByCurrentUser { get; set; }
    }
    
    public class GetCardSetsQueryHandler : IRequestHandler<GetCardSetsQuery, PaginatorResult<CardSetDto>>
    {   
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetCardSetsQueryHandler(IApplicationDbContext context, IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatorResult<CardSetDto>> Handle(GetCardSetsQuery request,
            CancellationToken cancellationToken)
        {
            if (request.PageIndex < 0)
            {
                throw new PaginatorException("Page index cannot be less than 0.");
            }

            var cardSets = request.ByCurrentUser
                ? _context.CardSets.Where(cardSet => cardSet.CreatedBy == _currentUserService.UserId)
                : _context.CardSets.Where(cardSet => cardSet.Status == CardSetStatus.Public);

            return await PaginatorResult<CardSetDto>.CreateAsyncWithMapping(
                cardSets,
                request.PageIndex,
                request.PageSize,
                _mapper.Map<List<CardSet>, List<CardSetDto>>
            );
        }
    }
}