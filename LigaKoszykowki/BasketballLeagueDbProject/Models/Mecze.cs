using System;
using System.Collections.Generic;

namespace BasketballLeagueDbProject.Models;

public partial class Mecze
{
    public int IdMeczu { get; set; }

    public int IdSedziego { get; set; }

    public DateTime DataMeczu { get; set; }

    public string Miejsce { get; set; } = null!;

    public virtual Sedziowie Sedzia { get; set; } = null!;

    public virtual ICollection<StatystykiMeczowe> StatystykiMeczowe { get; set; } = new List<StatystykiMeczowe>();
}
