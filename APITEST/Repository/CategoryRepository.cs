using APITEST.Data;
using APITEST.Interfaces;
using APITEST.Model;
using AutoMapper;

namespace APITEST.Repository
{
    public class CategoryRepository : ICategoryRepository
    {  
        private DataContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(DataContext context)
        { 
         _context = context;
        
        }
        public bool CategoryExist(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonsByCategory(int CategoryId)
        {
            return _context.PokemonCategories.Where(p => p.CategoryId == CategoryId).Select(p => p.Pokemon).ToList();
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
    }
}
