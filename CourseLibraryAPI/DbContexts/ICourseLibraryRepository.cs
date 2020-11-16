using CourseLibraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibraryAPI.DbContexts
{
    interface ICourseLibraryRepository
    {
        void AddCourse(Guid authorId, Course course);
        void DeleteCourse(Course course);
        Course GetCourse(Guid authorId, Guid courseId);
        IEnumerable<Course> GetCourses(Guid authorId);
        void UpdateCourse(Course course);
        void AddAuthor(Author author);
        bool AuthorExists(Guid authorId);
    }
}
