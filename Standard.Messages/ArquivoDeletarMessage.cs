using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Standard.Messages
{
    [DataContract(Namespace = "http://www.Standard.com/Arquivo/type")]
    public class ArquivoDeletarMessage
    {
        [DataMember(Name = "caminhoOrigem")]        
        [Required(ErrorMessage = "Campo requerido")]
        public string CaminhoOrigem { get; set; }
    }
}
