using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasMarcos.Models
{
    class ClientesView : Clientes
    {
        public string Telefone { get; set; } = null!;
    }
}
