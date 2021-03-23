using System;
using System.Linq;

namespace Assignment3.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private MovieDbContext _context;
        //constructor
        public EFMovieRepository (MovieDbContext context)
        {
            _context = context;
        }

        public IQueryable<ApplicationResponse> Movies => _context.Movies;
    }
}
