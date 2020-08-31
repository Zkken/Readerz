using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reader.Application.Common.Interfaces;
using Reader.Application.Common.Models;

namespace Reader.Application.Text.Queries.GetProcessedText
{
    public class GetProcessedTextQuery : IRequest<TextProcessingResult>
    {
        public string Text { get; set; }
    }
    
    public class GetProcessedTextQueryHandler : IRequestHandler<GetProcessedTextQuery, TextProcessingResult>
    {
        private readonly ITextProcessingService _textProcessingService;

        public GetProcessedTextQueryHandler(ITextProcessingService textProcessingService)
        {
            _textProcessingService = textProcessingService;
        }

        public async Task<TextProcessingResult> Handle(GetProcessedTextQuery request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Text))
            {
                throw new ArgumentException($"{nameof(request.Text)} is null or empty");
            }

            return await Task.Run(() => _textProcessingService.Process(request.Text), cancellationToken);
        }
    }
}