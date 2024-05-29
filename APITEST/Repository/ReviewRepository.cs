using APITEST.Data;
using APITEST.Interfaces;
using APITEST.Model;
using AutoMapper;

namespace APITEST.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReviewRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public Review GetReview(int id)
        {
            return _context.Reviews.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviewOfPokemon(int pokeId)
        {
            return _context.Reviews.Where(p => p.Pokemon.Id == pokeId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _context.Reviews.Any(p => p.Id == reviewId);
        }

        public bool CreateReview(Review review)
        {
           _context.Add(review);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReview(Review review)
        {
            _context?.Update(review);
            return Save();
        }
    }
}
