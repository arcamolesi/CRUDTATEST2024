using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDTATEST2024.Models
{
    [Table("Vendas")]
    public class Venda
    {
        [Display(Name ="ID: ")]
        [Key]
        public int id { get; set; }

        [Display(Name = "Cliente: ")]
        public int clienteID{ get; set; }
        [ForeignKey("clienteID")]
        public Cliente cliente { get; set; }

        [Display(Name = "Data: ")]
        public DateTime data { get; set; }
    }
}
