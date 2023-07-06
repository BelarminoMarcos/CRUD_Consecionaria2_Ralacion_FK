using System;
using System.Collections.Generic;

namespace Consecionaria2.Model;

public partial class Cliente
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public int IdAutoC { get; set; }

    public virtual CatalogoAuto IdAutoCNavigation { get; set; } = null!;
}
