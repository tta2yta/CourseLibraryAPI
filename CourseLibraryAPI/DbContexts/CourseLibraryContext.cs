using CourseLibraryAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibraryAPI.DbContexts
{
    public class CourseLibraryContext :DbContext
    {
        public CourseLibraryContext(DbContextOptions<CourseLibraryContext> options)
            :base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
