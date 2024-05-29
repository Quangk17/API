using APITEST.Model;

namespace APITEST.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonsByCategory(int CategoryId);
        bool CategoryExist(int id);
        bool CreateCategory (Category category);
        bool Save();
        bool UpdateCategory(Category category);

    }
}
