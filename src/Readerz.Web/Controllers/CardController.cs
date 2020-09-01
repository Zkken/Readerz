using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reader.Application.Cards.Commands.CreateCardRange;
using Reader.Application.Cards.Commands.DeleteCard;
using Reader.Application.Cards.Commands.UpdateCard;

namespace Readerz.Web.Controllers
{
    [Authorize]
    public class CardController : BaseController
    {
        [HttpDelete ("{id}")]
        public async Task<ActionResult> Delete(int id) 
        {
            await Mediator.Send (new DeleteCardCommand { Id = id });

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateCardCommand command)
        {
            await Mediator.Send(new UpdateCardCommand
            {
                Id = command.Id,
                Back = command.Back,
                Front = command.Front
            });

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> CreateRange(CreateCardRangeCommand command)
        {
            await Mediator.Send(new CreateCardRangeCommand
            {
                Cards = command.Cards,
                CardSetId = command.CardSetId
            });

            return Ok();
        }
    }
}
