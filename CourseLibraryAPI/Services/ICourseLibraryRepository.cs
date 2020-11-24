using CourseLibraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibraryAPI.Services
{
   public interface ICourseLibraryRepository
    {
        void AddCourse(Guid authorId, Course course);
        void DeleteCourse(Course course);
        Course GetCourse(Guid authorId, Guid courseId);
        IEnumerable<Course> GetCourses(Guid authorId);
        void UpdateCourse(Course course);
        void AddAuthor(Author author);
        bool AuthorExists(Guid authorId);
        void DeleteAuthor(Author author);
        Author GetAuthor(Guid authorId);
        IEnumerable<Author> GetAuthors();
        IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds);
        IEnumerable<Course> GetAuthors(string mainCategory);
        void UpdateAuthor(Author author);
        bool Save();
        void Dispose();


    }
}
