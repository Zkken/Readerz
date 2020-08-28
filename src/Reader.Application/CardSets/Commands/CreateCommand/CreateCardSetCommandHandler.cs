using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reader.Application.Common.Interfaces;
using Readerz.Domain.Entities;

namespace Reader.Application.CardSets.Commands.CreateCommand
{
    public class CreateCardSetCommandHandler : IRequestHandler<CreateCardSetCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateCardSetCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCardSetCommand request, CancellationToken cancellationToken)
        {
            var cardSet = new CardSet
            {
                Name = request.Name,
                Status = request.Status,
                TextId = request.TextId,
                Cards = request.Cards.Select(c => new Card
                {
                    Front = c.Front,
                    Back = c.Back
                }).ToList()
            };
            
            _context.CardSets.Add(cardSet);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return cardSet.Id;
        }
    }
}