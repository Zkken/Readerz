using MediatR;
using Reader.Application.Common.Interfaces;
using Reader.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reader.Application.Text.Queries.GetSupportedLanguages
{
    public class LanguageVm
    {
        public IEnumerable<Language> Languages { get; set; }
    }

    public class GetSupportedLanguagesQuery : IRequest<LanguageVm>
    {
        public class GetSupportedLanguagesQueryHandler : IRequestHandler<GetSupportedLanguagesQuery, LanguageVm>
        {
            private readonly ITranslatiovService _translatiovService;

            public GetSupportedLanguagesQueryHandler(ITranslatiovService translatiovService)
            {
                _translatiovService = translatiovService;
            }

            public async Task<LanguageVm> Handle(GetSupportedLanguagesQuery request, CancellationToken cancellationToken)
            {
                return new LanguageVm
                {
                    Languages = await Task.Run(() => _translatiovService.SupportedLanguages, cancellationToken)
                };
            }
        }
    }
}
