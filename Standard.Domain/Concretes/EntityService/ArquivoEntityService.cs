using Standard.Domain.Abstractions.EntityService;
using Standard.Framework.Result.Abstractions;
using Standard.Framework.Result.Concretes;
using Standard.Infrastructure.Abstractions;
using Standard.Models.Entities;
using Standard.Models.Enums;
using System.IO;
using System.Threading.Tasks;

namespace Standard.Domain.Concretes.EntityService
{
    public class ArquivoEntityService : IArquivoEntityService
    {
        private ILogRepository LogRepository { get; }

        public ArquivoEntityService(ILogRepository logRepository)
        {
            LogRepository = logRepository;
        }
        
        public async Task<IDomainResult<bool>> CopiarAsync(string caminhoOrigem, string caminhoDestino)
        {
            IDomainResult<bool> result = new DomainResult<bool>() { Data = true };

            var logIniciado = Log.Criar(OperacaoArquivoEnum.Copiar, AcaoPassoEnum.Iniciado, caminhoOrigem, caminhoDestino, string.Empty);
            await LogRepository.IncluirAsync(logIniciado);

            if (!Directory.Exists(caminhoDestino))
                Directory.CreateDirectory(caminhoDestino);

            var diretorioOrigem = new DirectoryInfo(caminhoOrigem);

            foreach (FileInfo file in diretorioOrigem.GetFiles())
            {
                var nomeArquivo = file.Name;                

                var logExecutando = Log.Criar(OperacaoArquivoEnum.Copiar, AcaoPassoEnum.Executando, caminhoOrigem, caminhoDestino, "Copia do Arquivo", nomeArquivo);
                await LogRepository.IncluirAsync(logExecutando);

                string localArquivoOrigem = Path.Combine(caminhoOrigem, nomeArquivo);
                string localArquivoDestino = Path.Combine(caminhoDestino, nomeArquivo);

                IDomainResult<bool> resultCheckSum = ValidarCheckSum();

                File.Copy(localArquivoOrigem, localArquivoDestino, true);                
            }

            var logFinalizado = Log.Criar(OperacaoArquivoEnum.Copiar, AcaoPassoEnum.Finalizado, caminhoOrigem, caminhoDestino, string.Empty);
            await LogRepository.IncluirAsync(logFinalizado);

            result.Messages.Add("Arquivo(s) copiado(s) com sucesso.");

            return result;
        }

        public async Task<IDomainResult<bool>> MoverAsync(string caminhoOrigem, string caminhoDestino)
        {
            IDomainResult<bool> result = new DomainResult<bool>() { Data = true };

            var logIniciado = Log.Criar(OperacaoArquivoEnum.Mover, AcaoPassoEnum.Iniciado, caminhoOrigem, caminhoDestino, string.Empty);
            await LogRepository.IncluirAsync(logIniciado);

            if (!Directory.Exists(caminhoDestino))
                Directory.CreateDirectory(caminhoDestino);

            var diretorioOrigem = new DirectoryInfo(caminhoOrigem);

            foreach (FileInfo file in diretorioOrigem.GetFiles())
            {
                var nomeArquivo = file.Name;

                var logExecutando = Log.Criar(OperacaoArquivoEnum.Mover, AcaoPassoEnum.Executando, caminhoOrigem, caminhoDestino, "Mover do Arquivo", nomeArquivo);
                await LogRepository.IncluirAsync(logExecutando);

                string localArquivoOrigem = Path.Combine(caminhoOrigem, nomeArquivo);
                string localArquivoDestino = Path.Combine(caminhoDestino, nomeArquivo);

                IDomainResult<bool> resultCheckSum = ValidarCheckSum();

                File.Move(localArquivoOrigem, localArquivoDestino);
            }

            var logFinalizado = Log.Criar(OperacaoArquivoEnum.Mover, AcaoPassoEnum.Finalizado, caminhoOrigem, caminhoDestino, string.Empty);
            await LogRepository.IncluirAsync(logFinalizado);

            result.Messages.Add("Arquivo(s) movido(s) com sucesso.");

            return result;
        }

        public async Task<IDomainResult<bool>> DeletarAsync(string caminhoOrigem)
        {
            IDomainResult<bool> result = new DomainResult<bool>() { Data = true };

            var logIniciado = Log.Criar(OperacaoArquivoEnum.Deletar, AcaoPassoEnum.Iniciado, caminhoOrigem, string.Empty, string.Empty);
            await LogRepository.IncluirAsync(logIniciado);

            if (!Directory.Exists(caminhoOrigem))
            {
                result.Data = false;
                result.Messages.Add("Diretório não existente.");
                return result;
            }

            var diretorioOrigem = new DirectoryInfo(caminhoOrigem);

            foreach (FileInfo file in diretorioOrigem.GetFiles())
            {
                var nomeArquivo = file.Name;
                string localArquivoOrigem = Path.Combine(caminhoOrigem, nomeArquivo);

                var logExecutando = Log.Criar(OperacaoArquivoEnum.Deletar, AcaoPassoEnum.Executando, caminhoOrigem, string.Empty, "Exclusão do Arquivo", nomeArquivo);
                await LogRepository.IncluirAsync(logExecutando);

                File.Delete(localArquivoOrigem);
            }

            var logFinalizado = Log.Criar(OperacaoArquivoEnum.Deletar, AcaoPassoEnum.Finalizado, caminhoOrigem, string.Empty, string.Empty);
            await LogRepository.IncluirAsync(logFinalizado);

            result.Messages.Add("Arquivo(s) deletado(s) com sucesso.");

            return result;
        }

        public async Task<IDomainResult<bool>> EntregarAsync(string caminhoDestino)
        {
            IDomainResult<bool> result = new DomainResult<bool>() { Data = true };

            //Realizar interação com FTP

            result.Messages.Add("Arquivo(s) entregue(s) com sucesso.");

            return result;
        }

        public IDomainResult<bool> ValidarCheckSum()
        {
            IDomainResult<bool> result = new DomainResult<bool>() { Data = true };
            
            //result.Messages.Add("CheckSum inválido.");

            return result;
        }
    }
}
