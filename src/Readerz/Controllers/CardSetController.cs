using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reader.Application.Cards.Commands.DeleteCard;
using Reader.Application.CardSets.Commands.CreateCommand;
using Reader.Application.CardSets.Commands.DeleteCommand;
using Reader.Application.CardSets.Commands.UpdateCommand;
using Reader.Application.CardSets.Queries.GetCardSets;
using Reader.Application.CardSets.Queries.GetCardSetsAll;
using Reader.Application.CardSets.Queries.GetCardSetsByText;

namespace Readerz.Controllers
{
    [Authorize]
    public class CardSetController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<CardSetVm>> All()
        {
            return Ok(await Mediator.Send(new GetCardSetsAllQuery()));
        }
        
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateCardSetCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCardSetCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<DeleteCardCommand>> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCardSetCommand { CardSetId = id}));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CardSetVm>> ByCardCreator(int id)
        {
            return Ok(await Mediator.Send(new GetCardSetsQuery { UserId = id }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CardSetVm>> ByText(int id)
        {
            return Ok(await Mediator.Send(new GetCardSetByTextQuery {TextId = id}));
        }
    }
}