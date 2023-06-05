using System;
using System.Collections.Generic;

namespace BasketballLeagueDbProject.Models;

public partial class Nagrody
{
    public int IdNagrody { get; set; }

    public string Opis { get; set; } = null!;

    public virtual ICollection<Ligi> Ligi { get; set; } = new List<Ligi>();
}
