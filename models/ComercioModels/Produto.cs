using System.ComponentModel.DataAnnotations.Schema;

namespace democrud.models.ComercioModels
{
    [Table("tb_produto")]
    public class Produto
    {
        public int id {  get; set; }
        public string nome { get; set; }
        public decimal preco { get; set; }
    }
}
