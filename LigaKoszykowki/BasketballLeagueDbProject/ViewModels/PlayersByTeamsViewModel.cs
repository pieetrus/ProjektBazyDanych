using BasketballLeagueDbProject.Models;

namespace BasketballLeagueDbProject.ViewModels
{
    public class PlayersByTeamsViewModel
    {
        public IList<Zawodnicy> Players { get; set; }
        public IList<Zespoly> Teams { get; set; }
        public int DropdownId { get; set; }
    }
}
