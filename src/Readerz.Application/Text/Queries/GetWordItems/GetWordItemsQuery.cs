using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Readerz.Application.Common.Interfaces;
using Readerz.Application.Common.Models;

namespace Readerz.Application.Text.Queries.GetWordItems
{
    public class GetWordItemsQuery : IRequest<WordsResult>
    {
        public string Text { get; set; }
    }
    
    public class GetWordItemsQueryHandler : IRequestHandler<GetWordItemsQuery, WordsResult>
    {
        public async Task<WordsResult> Handle(GetWordItemsQuery request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Text))
            {
                throw new ArgumentException(nameof(request.Text));
            }

            return await Util.FindWordsAsync(request.Text);
        }
    }
}