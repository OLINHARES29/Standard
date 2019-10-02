using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Standard.Messages
{
    [DataContract(Namespace = "http://www.Standard.com/Arquivo/type")]
    public class ArquivoEntregarMessage
    {   
        [DataMember(Name = "caminhoDestino")]
        [Required(ErrorMessage = "Campo requerido")]
        public string CaminhoDestino { get; set; }
    }
}
