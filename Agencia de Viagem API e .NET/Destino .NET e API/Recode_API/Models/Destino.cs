using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recode_Api.Models
{

    [Table("Destino")]
    public class Destino
    {
        [Key]
        public int DestinoId { get; set; }
        [Required(ErrorMessage = "Informe o nome do destino")]
        [StringLength(50)]
        public string NomeDoDestino { get; set; }
    }
}