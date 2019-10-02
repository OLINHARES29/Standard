using NSubstitute;
using Standard.Domain.Abstractions.EntityService;
using Standard.Domain.Concretes.EntityService;
using Standard.Framework.Result.Abstractions;
using Standard.Framework.Result.Enums;
using Standard.Infrastructure.Abstractions;
using Standard.Models.Entities;
using System.Threading.Tasks;
using Xunit;

namespace Standard.UnitTest
{
    public class ArquivoEntityServiceTest
    {
        private IArquivoEntityService ArquivoEntityService { get; }
        private ILogRepository LogRepository { get; }
        
        ArquivoEntityService task;

        public ArquivoEntityServiceTest()
        {
            ArquivoEntityService = Substitute.For<IArquivoEntityService>();
            LogRepository = Substitute.For<ILogRepository>();
        }

        private const string CONST_CAMINHO_ORIGEM = "C:\\Users\\Orlando\\Desktop\\Globo\\LocalOrigem";
        private const string CONST_CAMINHO_DESTINO = "C:\\Users\\Orlando\\Desktop\\Globo\\LocalDestino";

        [Theory]
        [InlineData(CONST_CAMINHO_ORIGEM, CONST_CAMINHO_DESTINO)]
        public async Task Valida_copia_arquivos(string caminhoOrigem, string caminhoDestino)
        {
            // Arrange
            await LogRepository.IncluirAsync(Arg.Any<Log>());

            // Act
            task = new ArquivoEntityService(LogRepository);
            IDomainResult<bool> result = await task.CopiarAsync(caminhoOrigem, caminhoDestino);

            // Assert            
            Assert.True(result.ResultType == DomainResultType.Success);
        }

        //public async Task Invalida_copia_arquivos(string caminhoOrigem, string caminhoDestino)

        //public async Task Valido_mover_arquivos(string caminhoOrigem, string caminhoDestino)

        //public async Task Invalido_mover_arquivos(string caminhoOrigem, string caminhoDestino)

        //public async Task Valido_deletar_arquivos(string caminhoOrigem)

        //public async Task Invalido_deletar_arquivos(string caminhoOrigem)

        //public async Task Valido_entregar_arquivos(string caminhoDestino)

        //public async Task Invalido_entregar_arquivos(string caminhoDestino)

    }
}
