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

        public IEnumerable<Course> GetCourses(Guid authorID)
        {
            if (authorID == null)
            {
                throw new ArgumentNullException(nameof(authorID));

            }

            return _context.Courses.Where(c => c.AuthorId == authorID).OrderBy(t => t.Title).ToList();
        }

        public void AddCourse(Guid authorID, Course course)
        {
            if(authorID == null)
            {
                throw new ArgumentNullException(nameof(authorID));
            }
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            course.AuthorId = authorID;
            _context.Courses.Add(course);

        }
        public void DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);

        }
        public void AddAurthur(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            author.Id =  Guid.NewGuid();
            foreach(var course in author.Courses)
            {
                course.Id =  Guid.NewGuid();
            }

            _context.Authors.Add(author);

        }

        public bool AuthorExist(Guid AuthorID)
        {
            if (AuthorID == null)
            {
                throw new ArgumentNullException(nameof(AuthorID));
            }
          return  _context.Authors.Any(a => a.Id == AuthorID);
          
        }
        public void DeleteAuthor(Author author)
        {
            if (author == null)
            {
                throw new ArgumentException(nameof(author));
            }
            _context.Authors.Remove(author);
           
        }
        public Author GetAuthor(Guid authorID)
        {
            if (authorID == null)
            {
                throw new ArgumentNullException(nameof(authorID));
            }

            //return _context.Authors.Where(a => a.Id == authorID).SingleOrDefault();
            return _context.Authors.FirstOrDefault(a => a.Id == authorID);

        }

    }
}
