using System.ComponentModel.DataAnnotations.Schema;

namespace democrud.models.ComercioModels
{
    [Table("tb_cliente")]
    public class Cliente
    {
        public int id {  get; set; }
        //[Column("name")]
        public string name { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
    }
}
