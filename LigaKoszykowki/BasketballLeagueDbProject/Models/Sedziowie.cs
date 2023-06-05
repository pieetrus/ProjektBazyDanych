using System;
using System.Collections.Generic;

namespace BasketballLeagueDbProject.Models;

public partial class Sedziowie
{
    public int IdSedziego { get; set; }

    public string Imie { get; set; } = null!;

    public string Nazwisko { get; set; } = null!;

    public virtual ICollection<Mecze> Mecze { get; set; } = new List<Mecze>();
}
