using System.ComponentModel.DataAnnotations.Schema;

namespace democrud.models.ComercioModels
{
    [Table("tb_cliente")]
    public class Cliente
    {
        public int id {  get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
    }
}
