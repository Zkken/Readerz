using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reader.Application.CardSets.Commands.CreateCommand;
using Reader.Application.CardSets.Commands.UpdateCommand;

namespace Readerz.Controllers
{
    [Authorize]
    public class CardSetController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<int>> CreateCardSet([FromBody] CreateCardSetCommand command)
        {
            var cardSetId = await Mediator.Send(command);

            return Ok(cardSetId);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCardSet([FromBody] UpdateCardSetCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}