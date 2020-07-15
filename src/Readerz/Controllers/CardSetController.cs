using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reader.Application.Cards.Commands.DeleteCard;
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCardSet([FromBody] UpdateCardSetCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteCardSet(int id)
        {
            await Mediator.Send(new DeleteCardCommand { Id = id });

            return NoContent();
        }
    }
}