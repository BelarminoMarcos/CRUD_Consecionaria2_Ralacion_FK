using System;
using System.Collections.Generic;

namespace Consecionaria2.Model;

public partial class CatalogoAuto
{
    public int Id { get; set; }

    public string Marca { get; set; } = null!;

    public int Modelo { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
