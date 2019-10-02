using Microsoft.AspNetCore.Mvc;
using Standard.Application.Abstractions;
using Standard.Framework.Result.Abstractions;
using Standard.Messages;
using System.Threading.Tasks;

namespace Standard.WebApi.Controllers
{
    [Route("api/arquivo")]
    public class ArquivoController : Controller
    {
        private IArquivoApplication ArquivoApplication { get; }

        public ArquivoController(IArquivoApplication arquivoApplication)
        {
            ArquivoApplication = arquivoApplication;
        }

        [HttpGet("wellcome"), Produces("text/plain", Type = typeof(string))]
        public string GetWellcome() => "Wellcome to service!";

        [HttpPost("copiar"), Produces("application/json", Type = typeof(IApplicationResult<bool>))]
        public virtual async Task<IActionResult> CopiarAsync([FromBody] ArquivoCopiarMessage message)
        {
            return await ArquivoApplication.CopiarAsync(message);
        }

        [HttpPost("mover"), Produces("application/json", Type = typeof(IApplicationResult<bool>))]
        public virtual async Task<IActionResult> MoverAsync([FromBody] ArquivoMoverMessage message)
        {
            return await ArquivoApplication.MoverAsync(message);
        }

        [HttpDelete, Produces("application/json", Type = typeof(IApplicationResult<bool>))]
        public virtual async Task<IActionResult> DeletarAsync([FromBody] ArquivoDeletarMessage message)
        {
            return await ArquivoApplication.DeletarAsync(message);
        }

        [HttpPost("entregar"), Produces("application/json", Type = typeof(IApplicationResult<bool>))]
        public virtual async Task<IActionResult> EntregarAsync([FromBody] ArquivoEntregarMessage message)
        {
            return await ArquivoApplication.EntregarAsync(message);
        }
    }
}