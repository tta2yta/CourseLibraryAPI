using CourseLibraryAPI.DbContexts;
using CourseLibraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibraryAPI.Services
{
    public class CourseLibraryRepository
    {
        private readonly CourseLibraryContext _context;

        public CourseLibraryRepository(CourseLibraryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Course GetCourse(Guid CourseId, Guid AuthorId)
        {
            if (CourseId == null)
            {
                throw new ArgumentNullException(nameof(CourseId));
            }
            if (AuthorId == null)
            {
                throw new ArgumentNullException(nameof(AuthorId));
            }

            return _context.Courses.Where(res => res.Id == AuthorId && res.Id == CourseId).FirstOrDefault();
        }

    }
}
