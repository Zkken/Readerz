using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reader.Application.Cards.Commands.CreateRangeCommand;
using Reader.Application.Cards.Commands.DeleteCard;
using Reader.Application.Cards.Commands.UpdateCard;
using Reader.Application.Cards.Queries.GetCardsByCardSet;

namespace Readerz.Controllers
{
    [Authorize]
    public class CardController : BaseController
    {
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CardListVm>> GetBySet(int id)
        {
            return Ok(await Mediator.Send(new GetCardsByCardSetQuery { Id = id }));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCardCommand { Id = id });

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateRange(CreateCardRangeCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(CardDto card)
        {
            await Mediator.Send(new UpdateCardCommand { });

            return NoContent();
        }
    }
}
