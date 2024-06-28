using System;
using System.Collections.Generic;

namespace VendasMarcos.Models;

public partial class Usuario
{
    public int Codigo { get; set; }

    public string Login { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string? Endereco { get; set; }

    public string? Email { get; set; }

    public bool Baixacontas { get; set; }

    public bool Sawversionnotes { get; set; }

    public string? Pass { get; set; }

    public bool Estornavenda { get; set; }

    public bool Estornaduplicata { get; set; }

    /// <summary>
    /// 1 - White List, 2 - Black List
    /// </summary>
    public int Methodaccessforms { get; set; }

    public DateTime Lastupdatepdvinfo { get; set; }

    public bool Admin { get; set; }

    public bool Faturavenda { get; set; }

    public bool Gerenciapedidos { get; set; }

    public bool Faturarvendadatahoraespecifica { get; set; }

    public bool Baixarcontasretroativo { get; set; }
}
