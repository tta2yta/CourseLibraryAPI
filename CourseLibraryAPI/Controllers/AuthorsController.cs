using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLibraryAPI.Model;
using CourseLibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibraryAPI.Controllers
{

    [ApiController]
    [Route("api/authors")]
    //[Route("api/[Controller]")]
    public class AuthorsController : ControllerBase
    {
        public readonly ICourseLibraryRepository _courseLibraryRepository;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
        {
            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(
                nameof(courseLibraryRepository));
                
        }

        //[HttpGet("api/authors")]
       [HttpGet()]
        public IActionResult GetAurthors()
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors();
            var authors = new List<AuthorDto>();

            foreach(var author in authorsFromRepo)
            {
                authors.Add(new AuthorDto()
                {
                    Guid = author.Id,
                    Name = $"{author.FirstName} {author.LastName}",
                    MainCategory = author.MainCategory,
                    Age = author.DateOfBirth.GetCurrentAge()
                });
            }

          //  return new JsonResult(authors);
            return Ok(authors);
            
        }

            
        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(Guid authorid)
        {
            var author = _courseLibraryRepository.GetAuthor(authorid);
            if (author == null)
            {
                return NotFound();
            }
            return new JsonResult(author);
            //return Ok(author);
           
        }
    }
}
