using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reader.Application.Common.Exceptions;
using Reader.Application.Common.Interfaces;
using Readerz.Domain.Entities;

namespace Reader.Application.CardSets.Queries.GetCardSets
{
    public class GetCardSetsQueryHandler : IRequestHandler<GetCardSetsQuery, CardSetVm>
    {   
        private readonly IReaderzDbContext _context;
        private readonly IMapper _mapper;

        public GetCardSetsQueryHandler(IReaderzDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CardSetVm> Handle(GetCardSetsQuery request, CancellationToken cancellationToken)
        {
            var cardCreator = await _context.CardCreators.Include(c => c.CardSets)
                .FirstOrDefaultAsync(c => c.CardCreatorId == request.UserId, cancellationToken);
            
            if(cardCreator == null)
            {
                throw new NotFoundException(nameof(CardCreator), request.UserId);
            }

            var res = _mapper.Map<ICollection<CardSetDto>>(cardCreator.CardSets);
            return new CardSetVm {CardSetDtos = res};
        }
    }
}