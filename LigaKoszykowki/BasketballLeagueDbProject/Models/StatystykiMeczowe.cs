using System;
using System.Collections.Generic;

namespace BasketballLeagueDbProject.Models;

public partial class StatystykiMeczowe
{
    public int IdStatystyk { get; set; }

    public int IdMeczu { get; set; }

    public int IdZawodnika { get; set; }

    public int LiczbaPunktow { get; set; }

    public int LiczbaAsyst { get; set; }

    public int LiczbaZbiorek { get; set; }

    public int LiczbaBlokow { get; set; }

    public int LiczbaPrzechwytow { get; set; }

    public virtual Mecze Mecz { get; set; } = null!;

    public virtual Zawodnicy Zawodnik { get; set; } = null!;
}
