using System;
using System.Collections.Generic;

namespace BasketballLeagueDbProject.Models;

public partial class Zespoly
{
    public int IdZespolu { get; set; }

    public int IdTrenera { get; set; }

    public string Nazwa { get; set; } = null!;

    public int RokZalozenia { get; set; }

    public virtual Trenerzy Trener { get; set; } = null!;

    public virtual ICollection<WynikiLigowe> WynikiLigowe { get; set; } = new List<WynikiLigowe>();

    public virtual ICollection<Zawodnicy> Zawodnicy { get; set; } = new List<Zawodnicy>();

    public virtual ICollection<Turnieje> Turnieje { get; set; } = new List<Turnieje>();
}
