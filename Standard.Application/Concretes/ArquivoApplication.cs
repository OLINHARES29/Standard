using Standard.Application.Abstractions;
using Standard.Domain.Abstractions.EntityService;
using Standard.Framework.Result.Abstractions;
using Standard.Framework.Result.Mappers;
using Standard.Messages;
using System.Threading.Tasks;

namespace Standard.Application.Concretes
{
    public class ArquivoApplication : IArquivoApplication
    {
        private IArquivoEntityService ArquivoEntityService { get; }

        public ArquivoApplication(IArquivoEntityService arquivoEntityService)
        {
            ArquivoEntityService = arquivoEntityService;
        }

        public async Task<IApplicationResult<bool>> CopiarAsync(ArquivoCopiarMessage message)
        {
            IDomainResult<bool> domainResult = await ArquivoEntityService.CopiarAsync(message.CaminhoOrigem, message.CaminhoDestino);
            return ResultMapper.MapFromDomainResult(domainResult, (domain) => domain);
        }

        public async Task<IApplicationResult<bool>>MoverAsync(ArquivoMoverMessage message)
        {
            IDomainResult<bool> domainResult = await ArquivoEntityService.MoverAsync(message.CaminhoOrigem, message.CaminhoDestino);
            return ResultMapper.MapFromDomainResult(domainResult, (domain) => domain);
        }

        public async Task<IApplicationResult<bool>> DeletarAsync(ArquivoDeletarMessage message)
        {
            IDomainResult<bool> domainResult = await ArquivoEntityService.DeletarAsync(message.CaminhoOrigem);
            return ResultMapper.MapFromDomainResult(domainResult, (domain) => domain);
        }

        public async Task<IApplicationResult<bool>> EntregarAsync(ArquivoEntregarMessage message)
        {
            IDomainResult<bool> domainResult = await ArquivoEntityService.EntregarAsync(message.CaminhoDestino);
            return ResultMapper.MapFromDomainResult(domainResult, (domain) => domain);
        }
    }
}
