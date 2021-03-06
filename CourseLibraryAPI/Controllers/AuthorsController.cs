﻿using System;
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
    [ApiController]
    [Route("api/authors")]
    //[Route("api/[Controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;


        public AuthorsController(ICourseLibraryRepository courseLibraryRepository,
           IMapper mapper )
        {
            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(
                nameof(courseLibraryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                
        }

        //[HttpGet("api/authors")]
       [HttpGet()]
        public ActionResult<IEnumerable<AuthorDto>> GetAurthors()
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors();
            /* var authors = new List<AuthorDto>();

             foreach(var author in authorsFromRepo)
             {
                 authors.Add(new AuthorDto()
                 {
                     Guid = author.Id,
                     Name = $"{author.FirstName} {author.LastName}",
                     MainCategory = author.MainCategory,
                     Age = author.DateOfBirth.GetCurrentAge()
                 });

             }*/
            //Using Mapper

            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));

          //  return new JsonResult(authors);
           // return Ok(authors);
            
        }

            
        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(Guid authorid)
        {
            var author = _courseLibraryRepository.GetAuthor(authorid);
            if (author == null)
            {
                return NotFound();
            }
            // return new JsonResult(author);
            //return Ok(author);

            return Ok(_mapper.Map<AuthorDto>(author));
        }
    }
}
