using System;
using System.Collections.Generic;

namespace VendasMarcos.Models;

public partial class ClientesTelefones
{
    public int Codigo { get; set; }

    public int Codcliente { get; set; }

    public string Tipo { get; set; } = null!;

    public int? Ddi { get; set; }

    public int? Ddd { get; set; }

    public string Telefone { get; set; } = null!;

    public int? Ramal { get; set; }

    public bool Principal { get; set; }

    public DateTime Lastupdateinfo { get; set; }
}
