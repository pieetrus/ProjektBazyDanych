using System;
using System.Collections.Generic;

namespace BasketballLeagueDbProject.Models;

public partial class SystemyRozgrywek
{
    public int IdSystemuRozgrywek { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual ICollection<Turnieje> Turnieje { get; set; } = new List<Turnieje>();
}
