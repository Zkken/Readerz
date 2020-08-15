using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reader.Application.Common.Interfaces;
using Reader.Application.Common.Models;
using Reader.Application.Text.Queries;
using Reader.Application.Text.Queries.GetProcessedTextQuery;
using Reader.Application.Text.Queries.GetSupportedLanguages;
using Reader.Application.Text.Queries.GetWordTranlsation;

namespace Readerz.Controllers
{
    [Authorize]
    public class TextController : BaseController
    {
        private readonly ILogger<TextController> _logger;

        public TextController(ILogger<TextController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<TranslationResult>> TranslateWord(
            [FromQuery] string text, 
            [FromQuery] string to, 
            [FromQuery] string from
            )
        {
            return Ok(await Mediator.Send(new GetWordTranslationQuery
            {
                Text = text,
                To = to,
                From = from
            }));
        }

        [HttpGet]
        public async Task<ActionResult<LanguageVm>> GetSupportedLanguages()
        {
            return Ok(await Mediator.Send(new GetSupportedLanguagesQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<TextProcessingResult>> Process([FromQuery] string text)
        {
            return Ok(await Mediator.Send(new GetProcessedTextQuery {Text = text}));
        }
    }
}