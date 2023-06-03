using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektyBazyDanych.Entities;
using ProjektyBazyDanych.Models;
using ProjektyBazyDanych.ViewModels;
using System.Diagnostics;

namespace ProjektyBazyDanych.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly ProjectsDbContext _context;

        public HomeController(ILogger<HomeController> logger, ProjectsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProjectType(Rodzaj rodzaj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Rodzaje.Add(rodzaj);
                    _context.SaveChanges();
                    ModelState.Clear();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    ModelState.AddModelError("Nazwa", "Nazwa jest polem unikalnym. Rodzaj o takiej nazwie znajduje się już w bazie danych.");
                }

            }

            return View("AddProjectType");
        }

        public IActionResult AddProjectStatus()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProjectStatus(Status status)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Statusy.Add(status);
                    _context.SaveChanges();
                    ModelState.Clear();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    ModelState.AddModelError("Nazwa", "Nazwa jest polem unikalnym. Status o takiej nazwie znajduje się już w bazie danych.");
                }

            }

            return View("AddProjectStatus");
        }

        public IActionResult AddProjectType()
        {
            return View();
        }

        [HttpPut]
        public ActionResult EditProjectType(Rodzaj rodzaj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var projectType = _context.Rodzaje.FirstOrDefault(x => x.Id == rodzaj.Id);

                    if (projectType == null)
                    {
                        throw new Exception("Rodzaj projektu o takim id nie został znaleziony");
                    }

                    projectType.Nazwa = rodzaj.Nazwa;

                    var success = _context.SaveChanges() > 0;

                    if (success)
                    {
                        return Ok();
                    }
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    ModelState.AddModelError("Nazwa", "Nazwa jest polem unikalnym. Status o takiej nazwie znajduje się już w bazie danych.");
                }
            }

            return View("EditProjectType");
        }

        [HttpPut]
        public ActionResult EditProjectStatus(Status status)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var projectStatus= _context.Statusy.FirstOrDefault(x => x.Id == status.Id);

                    if (projectStatus == null)
                    {
                        throw new Exception("Status projektu o takim id nie został znaleziony");
                    }

                    projectStatus.Nazwa = status.Nazwa;

                    var success = _context.SaveChanges() > 0;

                    if (success)
                    {
                        return Ok();
                    }
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    ModelState.AddModelError("Nazwa", "Nazwa jest polem unikalnym. Status o takiej nazwie znajduje się już w bazie danych.");
                }
            }

            return View("EditProjectStatus");
        }

        [HttpDelete]
        public ActionResult DeleteProjectType(int id)
        {
            var projectType = _context.Rodzaje.FirstOrDefault(x => x.Id == id);

            if (projectType == null)
            {
                throw new Exception("Rodzaj projektu o takim id nie został znaleziony");
            }

            _context.Rodzaje.Remove(projectType);

            var success = _context.SaveChanges() > 0;

            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteProjectStatus(int id)
        {
            var projectStatus= _context.Statusy.FirstOrDefault(x => x.Id == id);

            if (projectStatus == null)
            {
                throw new Exception("Status projektu o takim id nie został znaleziony");
            }

            _context.Statusy.Remove(projectStatus);

            var success = _context.SaveChanges() > 0;

            return Ok();
        }

        public IActionResult EditProjectType()
        {
            var projectTypes = _context.Rodzaje.ToList();

            return View(projectTypes);
        }

        public IActionResult EditProjectStatus()
        {
            var projectStatuses = _context.Statusy.ToList();

            return View(projectStatuses);
        }

        [HttpGet]
        public IActionResult AddProject(ProjectFormViewModel projectFormVM)
        {
            if (projectFormVM == null)
            {
                projectFormVM = new ProjectFormViewModel();
            }

            var statuses = _context.Statusy.ToList();
            var types = _context.Rodzaje.ToList();

            projectFormVM.Projekt = new Projekt();
            projectFormVM.Projekt.DataRozpoczecia = DateTime.Now;
            projectFormVM.Projekt.DataZakonczenia = DateTime.Now;

            projectFormVM.Rodzaje = types;
            projectFormVM.Statusy = statuses;

            return View(projectFormVM);
        }

        [HttpPost]
        public IActionResult SubmitAddProject(ProjectFormViewModel projectFormVM)
        {
            var project = projectFormVM.Projekt;

            _context.Projekty.Add(project);

            _context.SaveChanges();
            ModelState.Clear();

            var statuses = _context.Statusy.ToList();
            var types = _context.Rodzaje.ToList();

            projectFormVM.Projekt = new Projekt();
            projectFormVM.Projekt.DataRozpoczecia = DateTime.Now;
            projectFormVM.Projekt.DataZakonczenia = DateTime.Now;

            projectFormVM.Rodzaje = types;
            projectFormVM.Statusy = statuses;

            return View("AddProject", projectFormVM);
        }

        public IActionResult Projects()
        {
            var projects = _context.Projekty
                .Include(x => x.Status)
                .Include(x => x.Rodzaj)
                .ToList();

            return View(projects);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}