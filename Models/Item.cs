using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDTATEST2024.Models
{
    [Table("Itens")]
    public class Item
    {
        [Display(Name = "ID: ")]
        [Key]
        public int id { get; set; }

        [Display(Name = "Venda: ")]
        public int vendaID { get; set; }
        [ForeignKey("vendaID")]
        public Venda venda { get; set; }

        [Display(Name = "Produto: ")]
        public int produtoID { get; set; }
        [ForeignKey("produtoID")]
        public Produto produto { get; set; }

        [Display(Name = "Quantidade: ")]
        [DisplayFormat(DataFormatString = "{0,10:N2}")]
        public float quantidade { get; set; }

        [Display(Name = "Valor: ")]
        [DisplayFormat(DataFormatString = "{0,10:N2}")]
        public float valor { get; set; }

    }
}
