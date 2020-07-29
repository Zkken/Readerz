using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reader.Application.Common.Interfaces;
using Reader.Application.Text.Queries.GetWordTranlsation;

namespace Readerz.Controllers
{
    [Authorize]
    public class TextController : BaseController
    {
        public async Task<ActionResult<object>> Get()
        {
            return new ActionResult<object>(new object());
        }

        [HttpGet]
        public async Task<ActionResult<TranslationResult>> TranslateWord(
            [FromQuery] string text, 
            [FromQuery] string to, 
            [FromQuery] string from="Auto"
            )
        {
            return Ok(await Mediator.Send(new GetWordTranslationQuery
            {
                Text = text,
                To = to,
                From = from
            }));
        }
    }
}