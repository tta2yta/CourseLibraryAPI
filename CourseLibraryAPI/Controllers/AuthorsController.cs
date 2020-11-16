using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLibraryAPI.DbContexts;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibraryAPI.Controllers
{

    [ApiController]
    public class AuthorsController : ControllerBase
    {
        public readonly ICourseLibraryRepository _courseLibraryRepository;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
        {
            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(
                nameof(courseLibraryRepository));
                
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
