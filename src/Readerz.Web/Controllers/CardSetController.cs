using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Readerz.Application.Cards.Commands.DeleteCard;
using Readerz.Application.CardSets.Commands.CreateCardSet;
using Readerz.Application.CardSets.Commands.DeleteCardSet;
using Readerz.Application.CardSets.Commands.UpdateCardSet;
using Readerz.Application.CardSets.Queries.GetCardSetDetail;
using Readerz.Application.CardSets.Queries.GetCardSets;
using Readerz.Application.CardSets.Commands.IncrementLikeCardSet;
using Readerz.Application.CardSets.Commands.IncrementTimesPlayedCardSet;
using Readerz.Application.Common.Models;

namespace Readerz.Web.Controllers
{
    [Authorize]
    public class CardSetController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateCardSetCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateCardSetCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteCardCommand>> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCardSetCommand { CardSetId = id}));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<PaginatorResult<CardSetDto>>> Get(int pageIndex = 0, int pageSize = 10,
            bool byCurrentUser = false)
        {
            return Ok(await Mediator.Send(new GetCardSetsQuery
            {
                PageIndex = pageIndex, 
                PageSize = pageSize, 
                ByCurrentUser = byCurrentUser
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CardSetDetailDto>> GetDetail(int id)
        {
            return await Mediator.Send(new GetCardSetDetailQuery {CardSetId = id});
        }

        [HttpPut]
        public async Task<ActionResult> IncrementTimesPlayed(int id)
        {
             await Mediator.Send(new IncrementTimesPlayedCardSetCommand {Id = id});

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Like(int id)
        {
            await Mediator.Send(new IncrementLikeCardSetCommand {Id = id});
            
            return NoContent();
        }
    }
}