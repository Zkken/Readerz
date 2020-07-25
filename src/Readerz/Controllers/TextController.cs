using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Readerz.Controllers
{
    public class TextController : BaseController
    {
        public async Task<ActionResult<object>> Get()
        {
            return new ActionResult<object>(new object());
        }
    }
}