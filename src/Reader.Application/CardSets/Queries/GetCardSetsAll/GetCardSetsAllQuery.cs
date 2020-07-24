using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reader.Application.CardSets.Queries.GetCardSets;
using Reader.Application.Common.Interfaces;

namespace Reader.Application.CardSets.Queries.GetCardSetsAll
{
    public class GetCardSetsAllQuery : IRequest<CardSetVm>
    {
        public class GetCardSetsAllQueryHandler : IRequestHandler<GetCardSetsAllQuery, CardSetVm>
        {
            private readonly IReaderzDbContext _context;
            private readonly IMapper _mapper;
            
            public GetCardSetsAllQueryHandler(IReaderzDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<CardSetVm> Handle(GetCardSetsAllQuery request, CancellationToken cancellationToken)
            {
                var cardSetsDto = await _context.CardSets
                    .ProjectTo<CardSetDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken: cancellationToken);

                return new CardSetVm
                {
                    CardSetDtos = cardSetsDto
                };
            }
        }
    }
    

}