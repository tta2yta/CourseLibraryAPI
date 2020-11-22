using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibraryAPI.Profiles
{
    public class CoursesProfile :Profile
    {
        public CoursesProfile()
        {
            CreateMap<Entities.Course, Model.CourseDto>();
        }
        
    }
}
