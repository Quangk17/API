using APITEST.Model;

namespace APITEST.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        ICollection<Owner> GetOwnerFromACountry(int countryId);
        Boolean CountryExist(int Id);
        ICollection<Country> GetCountryByOwner(int ownerId);
        bool CreateCountry(Country country);
        bool UpdateCountry(Country country);
        bool Save();
    }
}
