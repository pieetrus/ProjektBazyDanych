using System;
using System.Collections.Generic;

namespace BasketballLeagueDbProject.Models;

public partial class Ligi
{
    public int IdLigi { get; set; }

    public int? IdNagrody { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual Nagrody? Nagroda { get; set; }

    public virtual ICollection<WynikiLigowe> WynikiLigowes { get; set; } = new List<WynikiLigowe>();
}
