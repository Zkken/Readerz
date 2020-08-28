using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Reader.Application.Common.Exceptions;
using Reader.Application.Common.Interfaces;
using Readerz.Domain.Entities;

namespace Reader.Application.Cards.Commands.CreateRangeCommand
{
    public class CreateCardRangeCommandHandler : IRequestHandler<CreateCardRangeCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCardRangeCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCardRangeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CardSets.FindAsync(request.CardSetId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CardSet), request.CardSetId);
            }

            var cards = _mapper.Map<ICollection<Card>>(request.CardDtos);
            foreach (var card in cards)
            {
                card.CardSetId = request.CardSetId;
            }
            
            _context.Cards.AddRange(cards);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}