﻿using CourseLibraryAPI.DbContexts;
using CourseLibraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibraryAPI.Services
{
    public class CourseLibraryRepository: ICourseLibraryRepository
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
            handdleNullExceptionTwoPar<Guid, Guid>(CourseId, AuthorId);

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
        public void AddAuthor(Author author)
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

        public bool AuthorExists(Guid AuthorID)
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
           /* if (authorID == null)
            {
                throw new ArgumentNullException(nameof(authorID));
            }*/
            handdleNullException<Guid>(authorID);

            //return _context.Authors.Where(a => a.Id == authorID).SingleOrDefault();
            return _context.Authors.FirstOrDefault(a => a.Id == authorID);

        }

        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors.ToList<Author>();
        }

        public IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorsID)
        {
            if (authorsID == null)
            {
                throw new ArgumentNullException(nameof(authorsID));
            }

            return _context.Authors.Where(a => authorsID.Contains(a.Id)).OrderBy(f=>f.FirstName).OrderBy(l=>l.LastName).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }

        public void UpdateCourse(Course course)
        {
            throw new NotImplementedException();
           
;        }

        public void UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }
        public void handdleNullException<T>(T obj1)
        {
            Console.WriteLine(obj1.GetType());
            if (obj1 == null)
            {
                throw new ArgumentNullException(nameof(obj1));
            }
        }
        public void handdleNullExceptionTwoPar<T1, T2>(T1 obj1, T2 obj2)
        {
            Console.WriteLine(obj1.GetType());
            if (obj1 == null)
            {
                throw new ArgumentNullException(nameof(obj1));
            }
            if (obj2 == null)
            {
                throw new ArgumentNullException(nameof(obj2));
            }
        }
    }
}
