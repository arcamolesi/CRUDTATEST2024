using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDTATEST2024.Models
{
    
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [Display(Name ="ID: ")]
        public int id { get; set; }

        [Display(Name ="Nome: ")]
        [StringLength(35)]
        [Required(ErrorMessage ="Campo nome é obrigatório")]
        public string nome { get; set; }

        [Display(Name ="Cidade: ")]
        [StringLength(25)]
        [Required(ErrorMessage ="Campo cidade é obrigatório...")]
        public string cidade { get; set; } 
    }
}
