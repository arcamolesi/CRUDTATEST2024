using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDTATEST2024.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Display(Name ="ID:")]
        [Key]
        public int id { get; set; }

        [Display(Name = "Descrição: ")]
        [StringLength(30)]
        [Required(ErrorMessage = "Campo descrição é obrigatório...")]
        public string descricao { get; set; }

        [Display(Name = "Quantidade: ")]
        [DisplayFormat(DataFormatString = "{0,10:N2}")]
        public float quantidade { get; set; }

        [Display(Name = "Valor: ")]
        [DisplayFormat(DataFormatString = "{0,10:N2}")]
        public float  valor { get; set; }
    }
}
