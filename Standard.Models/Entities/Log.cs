using Standard.Models.Enums;
using System;

namespace Standard.Models.Entities
{
    public class Log
    {
        public Log() { }

        public static Log Criar(OperacaoArquivoEnum operacao, AcaoPassoEnum acao, string caminhoOrigem, string caminhoDestino, string descricao)
        {
            return Criar(operacao, acao, caminhoOrigem, caminhoDestino, descricao, string.Empty);
        }

        public static Log Criar(OperacaoArquivoEnum operacao, AcaoPassoEnum acao, string caminhoOrigem, string caminhoDestino, string descricao, string nomeArquivo)
        {
            Log log = new Log
            {
                DataRegistro = DateTime.Now,
                Operacao = operacao.ToString(),
                Acao = acao.ToString(),
                CaminhoOrigem = caminhoOrigem,
                CaminhoDestino = caminhoDestino,
                Descricao = descricao,
                NomeArquivo = nomeArquivo,        
            };
            return log;            
        }

        public long Id { get; private set; }
        public DateTime DataRegistro { get; private set; }
        public string CaminhoOrigem { get; private set; }
        public string CaminhoDestino { get; private set; }
        public string Operacao { get; private set; }
        public string Acao { get; private set; }
        public string Descricao { get; private set; }
        public string NomeArquivo { get; private set; }
    }
}
