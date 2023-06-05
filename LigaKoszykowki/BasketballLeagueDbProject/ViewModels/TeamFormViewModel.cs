using BasketballLeagueDbProject.Models;

namespace BasketballLeagueDbProject.ViewModels
{
    public class TeamFormViewModel
    {
        public Zespoly Zespol { get; set; } 
        public IList<Trenerzy> Trenerzy { get; set; }
    }
}
