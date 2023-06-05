using BasketballLeagueDbProject.Data;
using BasketballLeagueDbProject.Models;
using BasketballLeagueDbProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjektyBazyDanych.ViewModels;
using System.Diagnostics;

namespace BasketballLeagueDbProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LigaKoszykowkiContext _context;

        public HomeController(ILogger<HomeController> logger, LigaKoszykowkiContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Players()
        {
            var players = _context.Zawodnicy
                .Include(x => x.Pozycja)
                .Include(x => x.Zespol)
                .ToList();

            return View(players);
        }

        public IActionResult PlayerForm(Zawodnicy player)
        {
            var vm = GetPopulatedPlayerFormViewModel(player);

            return View(vm);
        }

        [HttpPost]
        public IActionResult SubmitPlayerForm(PlayerFormViewModel playerVM)
        {
            var player = playerVM.Zawodnik;

            if (player.IdZawodnika == 0) //new player
            {
                //workaround due to bad db design
                var maxPlayerId = _context.Zawodnicy.ToList().GroupBy(r => r.IdZawodnika).OrderByDescending(g => g.Key).First().First().IdZawodnika;
                player.IdZawodnika = maxPlayerId + 1;

                _context.Zawodnicy.Add(player);
            }
            else // player update
            {
                var playerInDb = _context.Zawodnicy.FirstOrDefault(x => x.IdZawodnika == player.IdZawodnika);

                if (playerInDb is not null)
                {
                    playerInDb.Imie = player.Imie;
                    playerInDb.Nazwisko = player.Nazwisko;
                    playerInDb.IdPozycji = player.IdPozycji;
                    playerInDb.IdZespolu = player.IdZespolu;
                    playerInDb.Waga = player.Waga;
                    playerInDb.Wzrost = player.Wzrost;
                }
            }

            _context.SaveChanges();
            ModelState.Clear();

            var vm = GetPopulatedPlayerFormViewModel();

            return View("PlayerForm", vm);
        }

        [HttpPost]
        public IActionResult SubmitTeamForm(TeamFormViewModel teamVM)
        {
            var team = teamVM.Zespol;

            if (team.IdZespolu == 0) //new team
            {
                //workaround due to bad db design
                var maxTeamId = _context.Zespoly.ToList().GroupBy(r => r.IdZespolu).OrderByDescending(g => g.Key).First().First().IdZespolu;
                team.IdZespolu = maxTeamId + 1;

                _context.Zespoly.Add(team);
            }
            else // player update
            {
                var teamInDb = _context.Zespoly.FirstOrDefault(x => x.IdZespolu == team.IdZespolu);

                if (teamInDb is not null)
                {
                    teamInDb.Nazwa = teamInDb.Nazwa;
                    teamInDb.RokZalozenia = teamInDb.RokZalozenia;
                    teamInDb.IdTrenera = teamInDb.IdTrenera;
                }
            }

            _context.SaveChanges();
            ModelState.Clear();

            var vm = GetPopulatedTeamFormViewModel();

            return View("TeamForm", vm);
        }

        [HttpDelete]
        public IActionResult RemovePlayer(int id)
        {
            var player = _context.Zawodnicy.FirstOrDefault(x => x.IdZawodnika == id);

            _context.Zawodnicy.Remove(player);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult RemoveTeam(int id)
        {
            var team = _context.Zespoly.FirstOrDefault(x => x.IdZespolu == id);

            _context.Zespoly.Remove(team);

            _context.SaveChanges();

            return Ok();
        }

        public IActionResult Teams()
        {
            var teams = _context.Zespoly
                .Include(x => x.Trener)
                .ToList();

            return View(teams);
        }

        public IActionResult PlayersCharts()
        {
            var dict = _context.Zawodnicy.Include(x => x.Zespol)
                .GroupBy(x => x.Zespol).ToDictionary(x => x.Key, x => x.ToList());

            var model1 = new List<DataPoint>();

            foreach (var kvp in dict)
            {
                model1.Add(new DataPoint(kvp.Value.Count, kvp.Key.Nazwa));
            }
          
            ViewBag.DataPoints = JsonConvert.SerializeObject(model1, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

            return View();
        }

        public IActionResult Search(SearchViewModel vm)
        {
            var players = _context.Zawodnicy
                .Include(x => x.Pozycja)
                .Include(x => x.Zespol)
                .Where(x => x.Wzrost > vm.WzrostOd && x.Wzrost < vm.WzrostDo)
                .ToList();

            vm.Players = players;

            return View(vm);
        }

        [HttpGet]
        public IActionResult PlayersByTeams(PlayersByTeamsViewModel vm = null)
        {
            var players = _context.Zawodnicy
                .Include(x => x.Pozycja)
                .Include(x => x.Zespol)
                .Where(x => vm.DropdownId == 0 || x.IdZespolu == vm.DropdownId)
                .ToList();

            var teams = _context.Zespoly.ToList();

            vm.Players = players;
            vm.Teams = teams;

            return View(vm);
        }

        public IActionResult TeamForm(Zespoly team)
        {
            var vm = GetPopulatedTeamFormViewModel(team);

            return View(vm);
        }

        private TeamFormViewModel GetPopulatedTeamFormViewModel(Zespoly team = null)
        {
            var coaches = _context.Trenerzy.ToList();
            var vm = new TeamFormViewModel { Trenerzy = coaches, Zespol = team };
            
            return vm;
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        private PlayerFormViewModel GetPopulatedPlayerFormViewModel(Zawodnicy? player = null)
        {
            var positions = _context.Pozycje.ToList();
            var teams = _context.Zespoly.ToList();

            var vm = new PlayerFormViewModel { Pozycje = positions, Zawodnik = player, Zespoly = teams };

            return vm;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}