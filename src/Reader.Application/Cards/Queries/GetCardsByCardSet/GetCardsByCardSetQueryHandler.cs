using AutoMapper;
using MediatR;
using Reader.Application.Common.Exceptions;
using Reader.Application.Common.Interfaces;
using Readerz.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Reader.Application.Cards.Queries.GetCardsByCardSet
{
    public class GetCardsByCardSetQueryHandler : IRequestHandler<GetCardsByCardSetQuery, CardListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCardsByCardSetQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CardListVm> Handle(GetCardsByCardSetQuery request, CancellationToken cancellationToken)
        {
            var cardSet = await _context.CardSets.Include(c => c.Cards)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            
            if (cardSet == null)
            {
                throw new NotFoundException(nameof(CardSet), request.Id);
            }

            var cards = _mapper.Map<ICollection<CardDto>>(cardSet.Cards);
            return new CardListVm {Cards = cards};
        }
    }
}
