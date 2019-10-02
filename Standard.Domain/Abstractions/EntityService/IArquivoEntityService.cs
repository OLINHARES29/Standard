using Standard.Framework.Result.Abstractions;
using System.Threading.Tasks;

namespace Standard.Domain.Abstractions.EntityService
{
    public interface IArquivoEntityService
    {
        Task<IDomainResult<bool>> CopiarAsync(string caminhoOrigem, string caminhoDestino);
        Task<IDomainResult<bool>> MoverAsync(string caminhoOrigem, string caminhoDestino);
        Task<IDomainResult<bool>> DeletarAsync(string caminhoOrigem);
        Task<IDomainResult<bool>> EntregarAsync(string caminhoDestino);
    }
}
