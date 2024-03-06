using System;
using System.Collections.Generic;

namespace democrud.Models;

public partial class TbProduto
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public decimal? Preco { get; set; }

    public DateTime? DataCadastro { get; set; }
}
