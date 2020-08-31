using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reader.Application.Common.Interfaces;
using Readerz.Web.Domain.Entities;
using Readerz.Web.Domain.Enums;

namespace Reader.Application.CardSets.Commands.CreateCardSet
{
    public class CreateCardSetCommand : IRequest<int>
    {
        public string Name { get; set; }
        public CardSetStatus Status { get; set; }
        public int? TextId { get; set; }
    }
    
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
            };
            
            _context.CardSets.Add(cardSet);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return cardSet.Id;
        }
    }
}
