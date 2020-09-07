using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reader.Application.Common.Exceptions;
using Reader.Application.Common.Interfaces;
using Readerz.Domain.Entities;

namespace Reader.Application.Cards.Commands.CreateCardRange
{
    public class CreateCardRangeCommand : IRequest
    {
        public int CardSetId { get; set; }
        public IEnumerable<CardDto> Cards { get; set; }
    }
    
    public class CardDto
    {
        public string Front { get; set; }
        public string Back { get; set; }
    }   

    public class CreateCardRangCommandHandler : IRequestHandler<CreateCardRangeCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateCardRangCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateCardRangeCommand request, CancellationToken cancellationToken)
        {
            var cardSet =
                await _context.CardSets.FirstOrDefaultAsync(entity => entity.Id == request.CardSetId,
                    cancellationToken);
            
            if (cardSet == null)
            {
                throw new NotFoundException(nameof(request.CardSetId), typeof(CardSet));
            }

            _context.Cards.AddRange(request.Cards.Select(card => new Card
            {
                Front = card.Front,
                Back = card.Back,
                CardSetId = request.CardSetId
            }));

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}