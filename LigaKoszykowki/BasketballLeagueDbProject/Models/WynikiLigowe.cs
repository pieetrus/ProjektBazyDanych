using System;
using System.Collections.Generic;

namespace BasketballLeagueDbProject.Models;

public partial class WynikiLigowe
{
    public int IdLigi { get; set; }

    public int IdZespolu { get; set; }

    public int MiejsceWTabeli { get; set; }

    public int LiczbaWygranych { get; set; }

    public int LiczbaPrzegranych { get; set; }

    public virtual Ligi Liga { get; set; } = null!;

    public virtual Zespoly Zespol { get; set; } = null!;
}
