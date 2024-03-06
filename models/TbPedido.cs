using System;
using System.Collections.Generic;

namespace democrud.Models;

public partial class TbPedido
{
    public int PedidoId { get; set; }

    public DateTime? DataPedido { get; set; }

    public int? ClienteId { get; set; }

    public virtual TbCliente? Cliente { get; set; }
}
