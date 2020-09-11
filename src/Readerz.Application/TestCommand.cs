using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Readerz.Application.CardSets.Queries.GetCardSets;
using Readerz.Application.Common.Interfaces;

namespace Readerz.Application
{
    public class TestCommand : IRequest<List<CardSetDto>>
    {
        
    }

    public class TestCommandHandler : IRequestHandler<TestCommand, List<CardSetDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public TestCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CardSetDto>> Handle(TestCommand request, CancellationToken cancellationToken)
        {
            return await _context.CardSets.ProjectTo<CardSetDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}