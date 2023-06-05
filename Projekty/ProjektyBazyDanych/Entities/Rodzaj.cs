using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProjektyBazyDanych.Entities
{
    [Index(nameof(Nazwa), IsUnique = true)]
    public class Rodzaj
    {
        public int Id { get; set; }
        [Required]
        public string Nazwa { get; set; }
    }
}
