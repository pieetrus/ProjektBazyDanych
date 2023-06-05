using BasketballLeagueDbProject.Models;

namespace BasketballLeagueDbProject.ViewModels
{
    public class PlayerFormViewModel
    {
        public Zawodnicy Zawodnik { get; set; }
        public IList<Pozycje> Pozycje { get; set; }
        public IList<Zespoly> Zespoly { get; set; }
    }
}
