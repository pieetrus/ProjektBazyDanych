namespace ProjektyBazyDanych.ViewModels
{
	public class SearchViewModel
	{
		public string Nr { get; set; }
		public string Temat { get; set; }
		public DateTime? DataRozpoczecia { get; set; }
		public DateTime? DataZakonczenia { get; set; }
		public decimal? KwotaOd { get; set; }
		public decimal? KwotaDo { get; set; }
	}
}
