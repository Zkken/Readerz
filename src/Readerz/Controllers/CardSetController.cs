using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reader.Application.CardSets.Commands.CreateCommand;

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
    }
}