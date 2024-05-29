using APITEST.DTO;
using APITEST.Model;
using AutoMapper;

namespace APITEST.Help
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDTO>(); 
            CreateMap<Category, CategoryDTO>();
            CreateMap<Country, CountryDTO>();
            CreateMap<Owner, OwnerDTO>();
            CreateMap<Reviewer, ReviewerDTO>();
            CreateMap<Review, ReviewDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<CountryDTO, Country>();
            CreateMap<OwnerDTO, Owner>();
            CreateMap<PokemonDTO, Pokemon>();
            CreateMap<ReviewDTO, Review>();
            CreateMap<ReviewerDTO, Reviewer>();
        }
    }
}
