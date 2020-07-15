using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reader.Application.Cards.Commands.DeleteCard;
using Reader.Application.Cards.Querries.GetCardsByCardSet;

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
    }
}
