using CountriesWebApi.DTO;
using CountriesWebApi.Entities;
using CountriesWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CountriesWebApi.Controllers
{
    [ApiController]
    [Route("country")]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost]
        [Route("save")]
        public async Task<IEnumerable<Country>> SaveCountries()
        {
            return await _countryService.SaveCountriesAsync();
        }

        [HttpGet]
        [Route("get/all")]
        public IEnumerable<Country> GetCountries()
        {
            return _countryService.GetAll();
        }

        [HttpGet]
        [Route("get/{id}")]
        public Country GetById(int id)
        {
            return _countryService.GetById(id);
        }

        [HttpGet]
        [Route("getByRegion/{region}")]
        public Country GetByRegion(string region)
        {
            return _countryService.GetByRegion(region);
        }

        [HttpGet]
        [Route("getByName/{name}")]
        public IEnumerable<Country> FindName(string name)
        {
            return _countryService.FindName(name);
        }

        [HttpPost]
        [Route("create")]
        public void CreateCountry(Country country)
        {
            _countryService.CreateCountry(country);
        }
        [HttpPut]
        [Route("update")]
        public void UpdateCountry(Country country)
        {
            _countryService.UpdateCountry(country);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteCountry(int Id)
        {
            _countryService.DeleteCountry(Id);
        }
    }
}