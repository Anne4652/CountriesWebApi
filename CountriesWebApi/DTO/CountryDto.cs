using CountriesWebApi.Entities;

namespace CountriesWebApi.DTO
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public int Population { get; set; }
        public string Capital { get; set; }
        public string Subregion { get; set; }
        public string Alpha3Code { get; set; }
        public List<string> Borders { get; set; }
        public string Region { get; set; }
        public List<Language> Languages { get; set; }
        public List<Currency> Currencies { get; set; }
    }
}
