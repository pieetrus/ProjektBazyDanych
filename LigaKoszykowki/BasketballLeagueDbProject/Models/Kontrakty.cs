using System;
using System.Collections.Generic;

namespace BasketballLeagueDbProject.Models;

public partial class Kontrakty
{
    public int IdKontraktu { get; set; }

    public int IdZawodnika { get; set; }

    public DateTime DataPodpisania { get; set; }

    public DateTime DataWygasniecia { get; set; }

    public int WynagrodzenieRoczne { get; set; }

    public virtual Zawodnicy Zawodnik { get; set; } = null!;
}
