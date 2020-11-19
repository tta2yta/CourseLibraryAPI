using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibraryAPI.Model
{
    public class AuthorDto
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
     
        public int Age { get; set; }
        public string MainCategory { get; set; }
    }
}
