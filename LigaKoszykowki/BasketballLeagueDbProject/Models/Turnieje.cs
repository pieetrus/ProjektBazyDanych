using System;
using System.Collections.Generic;

namespace BasketballLeagueDbProject.Models;

public partial class Turnieje
{
    public int IdTurnieju { get; set; }

    public int IdSystemuRozgrywek { get; set; }

    public string Nazwa { get; set; } = null!;

    public DateTime RokRozpoczecia { get; set; }

    public DateTime RokZakonczenia { get; set; }

    public string Opis { get; set; } = null!;

    public virtual SystemyRozgrywek SystemyRozgrywek { get; set; } = null!;

    public virtual ICollection<Zespoly> Zespoly { get; set; } = new List<Zespoly>();
}
