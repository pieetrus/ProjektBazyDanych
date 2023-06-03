using ProjektyBazyDanych.Entities;

namespace ProjektyBazyDanych.ViewModels
{
    public class ProjectFormViewModel
    {
        public Projekt Projekt { get; set; }
        public IList<Status> Statusy { get; set; }
        public IList<Rodzaj> Rodzaje { get; set; }
    }
}
