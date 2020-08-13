using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reader.Application.CardCreator.Queries.GetCardCreatorId;

namespace Readerz.Controllers
{
    [Authorize]
    public class CardCreatorController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<int?>> Current()
        {
            return Ok(await Mediator.Send(new GetCardCreatorIdQuery()));
        }
    }
}