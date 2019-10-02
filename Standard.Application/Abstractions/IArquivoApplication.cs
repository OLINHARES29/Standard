using Standard.Framework.Result.Abstractions;
using Standard.Messages;
using System.Threading.Tasks;

namespace Standard.Application.Abstractions
{
    public interface IArquivoApplication
    {
        Task<IApplicationResult<bool>> CopiarAsync(ArquivoCopiarMessage message);
        Task<IApplicationResult<bool>> MoverAsync(ArquivoMoverMessage message);
        Task<IApplicationResult<bool>> DeletarAsync(ArquivoDeletarMessage message);
        Task<IApplicationResult<bool>> EntregarAsync(ArquivoEntregarMessage message);
    }
}
