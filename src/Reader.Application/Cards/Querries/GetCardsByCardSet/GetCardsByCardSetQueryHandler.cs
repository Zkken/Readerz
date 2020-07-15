using AutoMapper;
using MediatR;
using Reader.Application.Common.Exceptions;
using Reader.Application.Common.Interfaces;
using Readerz.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Reader.Application.Cards.Queries.GetCardsByCardSet
{
    public class GetCardsByCardSetQueryHandler : IRequestHandler<GetCardsByCardSetQuery, CardListVm>
    {
        private readonly IReaderzDbContext _context;
        private readonly IMapper _mapper;

        public GetCardsByCardSetQueryHandler(IReaderzDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CardListVm> Handle(GetCardsByCardSetQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.CardSets.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CardSet), request.Id);
            }

            var cards = _mapper.Map<IList<CardDto>>(entity.Cards);

            var vm = new CardListVm
            {
                Cards = cards
            };

            return vm;
        }
    }
}
