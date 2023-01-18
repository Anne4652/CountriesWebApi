using CountriesWebApi.Entities;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using CountriesWebApi.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CountriesWebApi.Services
{
    public class CountryService
    {
        private readonly CountriesDbContext _countriesDbContext;
        public CountryService(CountriesDbContext countriesDbContext)
        {
            _countriesDbContext = countriesDbContext;
        }

        public async Task<Country[]?> SaveCountriesAsync()
        {
            using (var client = new HttpClient())
            {
                await _countriesDbContext.Database.ExecuteSqlRawAsync("TRUNCATE public.\"Countries\" RESTART IDENTITY CASCADE;");
                //await _countriesDbContext.Database.ExecuteSqlRawAsync("TRUNCATE CASCADE public.\"Languages\" RESTART IDENTITY;");
                //await _countriesDbContext.Database.ExecuteSqlRawAsync("TRUNCATE CASCADE public.\"Currencies\" RESTART IDENTITY;");
                client.BaseAddress = new Uri("https://restcountries.com/v2/");
                //HTTP GET
                var responseTask = client.GetAsync("all");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadFromJsonAsync<Country[]>();
                    readTask.Wait();

                    var countries = readTask.Result;
                    _countriesDbContext.Countries.AddRange(countries);
                    _countriesDbContext.SaveChanges();
                    return countries;
                }
            }
            return null;
        }

        public IEnumerable<Country> GetAll()
        {
            return _countriesDbContext.Countries.Include(c => c.Languages).Include(c => c.Currencies);
        }

        public Country GetById(int id)
        {
            return _countriesDbContext.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetByRegion(string region)
        {
            return _countriesDbContext.Countries.Where(c => c.Region == region).FirstOrDefault();
        }

        public IEnumerable<Country> FindName(string name)
        {
            return _countriesDbContext.Countries.Where(c => c.Name.Contains(name));
        }

        public void CreateCountry(Country country)
        {
            _countriesDbContext.Countries.Add(country);
            _countriesDbContext.SaveChanges();
        }
        public void UpdateCountry(Country country)
        {
            _countriesDbContext.Countries.Update(country);
            _countriesDbContext.SaveChanges();
        }

        public void DeleteCountry(int Id)
        {
            var country = _countriesDbContext.Countries.FirstOrDefault(c => c.Id == Id);
            if(country == null)
            {
                return;
            }
            _countriesDbContext.Remove(country);
        }
    }
}
