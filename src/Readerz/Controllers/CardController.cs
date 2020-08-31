using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reader.Application.Cards.Commands.DeleteCard;
using Reader.Application.Cards.Commands.UpdateCard;

namespace Readerz.Controllers
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
        public async Task<ActionResult> Update(UpdateCardCommand card)
        {
            await Mediator.Send(new UpdateCardCommand
            {
                Id = card.Id,
                Back = card.Back,
                Front = card.Front
            });

            return NoContent();
        }
    }
}
