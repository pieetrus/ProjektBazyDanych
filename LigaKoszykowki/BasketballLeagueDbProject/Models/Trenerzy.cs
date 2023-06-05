using System;
using System.Collections.Generic;

namespace BasketballLeagueDbProject.Models;

public partial class Trenerzy
{
    public int IdTrenera { get; set; }

    public string Imie { get; set; } = null!;

    public string Nazwisko { get; set; } = null!;

    public DateTime DataUrodzenia { get; set; }

    public virtual ICollection<Zespoly> Zespoly { get; set; } = new List<Zespoly>();
}
