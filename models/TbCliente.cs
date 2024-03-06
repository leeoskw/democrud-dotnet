using System;
using System.Collections.Generic;

namespace democrud.Models;

public partial class TbCliente
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public string? Telefone { get; set; }

    public virtual ICollection<TbPedido> TbPedidos { get; } = new List<TbPedido>();
}
