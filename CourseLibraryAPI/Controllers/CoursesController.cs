using AutoMapper;
using CourseLibraryAPI.Model;
using CourseLibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibraryAPI.Controllers
{
    [ApiController]
    [Route("api/authors/{authorId}/courses/")]
    public class CoursesController:ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;
        public CoursesController(ICourseLibraryRepository courseLibraryRepository,
           IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(
                nameof(courseLibraryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }



        [HttpGet]
        public ActionResult<IEnumerable<Model.CourseDto>> GetCoursesForAuthor(Guid authorId)
        {
            if(!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var coursesForAuthorFromREpo = _courseLibraryRepository.GetCourses(authorId);
            return Ok(_mapper.Map<IEnumerable<CourseDto>>(coursesForAuthorFromREpo));

        }

       

        [HttpGet("{courseId}")]
        public ActionResult<CourseDto> GetCourseForAuthor(Guid authorId, Guid courseId)
        {
            if (!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }
            var courseForAuthorFromRepo = _courseLibraryRepository.GetCourse(authorId, courseId);
            if (courseForAuthorFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CourseDto>(courseForAuthorFromRepo));
        }

        [HttpPost]

        public ActionResult<CourseDto> CreateCourse(Guid authorId, CourseCreationDto course)
        {
            if (!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }


        }
    }
}
