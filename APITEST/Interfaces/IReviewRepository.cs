using APITEST.Model;

namespace APITEST.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        
        Review GetReview(int id);
        ICollection<Review> GetReviewOfPokemon(int pokeId);
        bool ReviewExists(int reviewId);
        bool CreateReview(Review review);
        bool UpdateReview(Review review);
        bool Save();
    }
}
