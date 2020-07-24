using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reader.Application.Cards.Queries.GetCardsByCardSet;
using Reader.Application.Common.Exceptions;
using Reader.Application.Common.Interfaces;
using Readerz.Domain.Entities;

namespace Reader.Application.CardSets.Commands.CreateCommand
{
    public class CreateCardSetCommandHandler : IRequestHandler<CreateCardSetCommand, int>
    {
        private readonly IReaderzDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public CreateCardSetCommandHandler(IReaderzDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> Handle(CreateCardSetCommand request, CancellationToken cancellationToken)
        {
            var creator = await _context.CardCreators
                .FirstOrDefaultAsync(c => c.UserId == _currentUserService.UserId, cancellationToken);
            
            //if card creator does not exist, create a new card creator, associate it 
            //with the identifier of the current user
            if (creator == null)
            {
                creator = new Readerz.Domain.Entities.CardCreator
                {
                    UserId = _currentUserService.UserId
                };
                _context.CardCreators.Add(creator);
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            //create new card set based on the received request
            var cardSet = new CardSet
            {
                Name = request.Name,
                Status = request.Status,
                TextId = request.TextId,
                CardCreatorId = creator.CardCreatorId,
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