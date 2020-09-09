using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Readerz.Application.Common.Exceptions;
using Readerz.Application.Common.Interfaces;
using Readerz.Domain.Entities;

namespace Readerz.Application.CardSets.Queries.GetCardSetDetail
{
    public class GetCardSetDetailQuery : IRequest<CardSetDetailDto>
    {
        public int CardSetId { get; set; }
    }

    public class GetCardSetDetailQueryHandler : IRequestHandler<GetCardSetDetailQuery, CardSetDetailDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCardSetDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CardSetDetailDto> Handle(GetCardSetDetailQuery request, CancellationToken cancellationToken)
        {
            var cardSet =
                await _context.CardSets
                    .Include(entity => entity.Cards)
                    .FirstOrDefaultAsync(entity => entity.Id == request.CardSetId, cancellationToken);

            if (cardSet == null)
            {
                throw new NotFoundException(nameof(request.CardSetId), typeof(CardSet));
            }

            var result = _mapper.Map<CardSet, CardSetDetailDto>(cardSet);
            
            result.Cards = _mapper.Map<List<Card>, List<CardDto>>(cardSet.Cards.ToList());

            return result;
        }
    }
}