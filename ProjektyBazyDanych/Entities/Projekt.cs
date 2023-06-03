namespace ProjektyBazyDanych.Entities
{
    public class Projekt
    {
        public int Id { get; set; }
        public string Nr { get; set; }
        public string Temat { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public DateTime DataZakonczenia { get; set; }
        public decimal Kwota { get; set; }
        public string Uwagi { get; set; }
        public Rodzaj Rodzaj { get; set; }
        public int RodzajId { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }
    }
}
