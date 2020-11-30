using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseLibraryAPI.Helpers;
using CourseLibraryAPI.Model;
using CourseLibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibraryAPI.Controllers
{
    public class AuthorCollectionController : Controller
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorCollectionController(ICourseLibraryRepository courseLibraryRepository, 
            IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }
        public ActionResult<IEnumerable<AuthorDto>> CreateAuthorCollection
            (IEnumerable<AuthorCreationDto> authorcollection)
        {
            var authorEntities = _mapper.Map<IEnumerable<Entities.Author>>(authorcollection);

            foreach(var author in authorEntities)
            {
                _courseLibraryRepository.AddAuthor(author);
            }
            _courseLibraryRepository.Save();
            return Ok();
        }

        [HttpGet("({ids})")]
        public IActionResult GetAuthorCollection(
            [FromRoute]
            [ModelBinder(BinderType =typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
           

        }
    }
}
