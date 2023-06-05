using System;
using System.Collections.Generic;

namespace BasketballLeagueDbProject.Models;

public partial class Pozycje
{
    public int IdPozycji { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual ICollection<Zawodnicy> Zawodnicy { get; set; } = new List<Zawodnicy>();
}
