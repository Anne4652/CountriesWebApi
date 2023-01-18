using System.ComponentModel.DataAnnotations;

namespace CountriesWebApi.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public int Population { get; set; }
        public string? Capital { get; set; }
        public string Subregion { get; set; }
        public string Alpha3Code { get; set; }
        public List<string>? Borders { get; set; }
        public virtual string Region { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<Currency> Currencies { get; set; }
    }
}
