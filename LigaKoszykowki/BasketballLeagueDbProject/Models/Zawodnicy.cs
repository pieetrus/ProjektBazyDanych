using System;
using System.Collections.Generic;

namespace BasketballLeagueDbProject.Models;

public partial class Zawodnicy
{
    public int IdZawodnika { get; set; }

    public int IdZespolu { get; set; }

    public int IdPozycji { get; set; }

    public string Imie { get; set; } = null!;

    public string Nazwisko { get; set; } = null!;

    public DateTime DataUrodzenia { get; set; }

    public decimal Wzrost { get; set; }

    public decimal Waga { get; set; }

    public virtual Pozycje Pozycja { get; set; } = null!;

    public virtual Zespoly Zespol { get; set; } = null!;

    public virtual ICollection<Kontrakty> Kontrakty { get; set; } = new List<Kontrakty>();

    public virtual ICollection<StatystykiMeczowe> StatystykiMeczowe { get; set; } = new List<StatystykiMeczowe>();
}
