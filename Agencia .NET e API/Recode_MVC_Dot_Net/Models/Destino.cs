using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recode_MVC_Dot_Net.Models
{
    [Table("Destino")]
    public class Destino
    {
        public int DestinoId { get; set; }
        [Display(Name = "Nome do Destino")]
        [Required]
        [StringLength(100)]
        public string NomeDoDestino { get; set; }
    }
}