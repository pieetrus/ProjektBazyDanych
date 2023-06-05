using BasketballLeagueDbProject.Models;

namespace BasketballLeagueDbProject.ViewModels
{
    public class SearchViewModel
    {
        public IList<Zawodnicy> Players { get; set; }
        public IList<Zespoly> Teams { get; set; }
        public int WzrostOd { get; set; }
        public int WzrostDo { get; set; }
    }
}
