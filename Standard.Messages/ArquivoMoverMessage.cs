using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Standard.Messages
{
    [DataContract(Namespace = "http://www.Standard.com/Arquivo/type")]
    public class ArquivoMoverMessage
    {
        private const string CAMPO_REQUERIDO = "Campo requerido";

        [DataMember(Name = "caminhoOrigem")]        
        [Required(ErrorMessage = CAMPO_REQUERIDO)]
        public string CaminhoOrigem { get; set; }

        [DataMember(Name = "caminhoDestino")]
        [Required(ErrorMessage = CAMPO_REQUERIDO)]
        public string CaminhoDestino { get; set; }
    }
}
