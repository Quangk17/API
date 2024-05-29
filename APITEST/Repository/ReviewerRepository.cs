using APITEST.Data;
using APITEST.Interfaces;
using APITEST.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace APITEST.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReviewerRepository(DataContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public bool createReviewer(Reviewer reviewer)
        {
            _context.Add(reviewer);
            return Save();
        }

        public bool CreateReviewer(Reviewer reviewer)
        {
            throw new NotImplementedException();
        }

        public ICollection<Review> GetReviewByReviewer(int reviewId)
        {
            return _context.Reviews.Where(p => p.Reviewer.Id == reviewId).ToList();
        }

        public Reviewer GetReviewer(int id)
        {
            return _context.Reviewers.Where(p => p.Id == id).Include(e =>e.Reviews).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.ToList();
        }

        public bool ReviewerExist(int reviewerId)
        {
           return _context.Reviewers.Any(p => p.Id == reviewerId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReviewer(Reviewer reviewer)
        {
           _context.Update(reviewer);
            return Save();
        }
    }
}
