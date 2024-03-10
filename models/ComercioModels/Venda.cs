namespace democrud.models.ComercioModels
{
    public class Venda
    {
        public int id { get; set; }
        public int cliente_id {  get; set; }
        public int produto_id {  get; set; }
        public DateTime dataVenda { get; set; }
    }
}
