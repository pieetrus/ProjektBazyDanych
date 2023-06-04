using ProjektyBazyDanych.Entities;

namespace ProjektyBazyDanych.ViewModels
{
    public class ProjectsByViewModel
    {
        public IList<Projekt> Projekty { get; set; }
        public IList<Rodzaj> Rodzaje { get; set; }
        public IList<Status> Statusy { get; set; }
        public int DropdownId { get; set; }
    }
}
