using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibraryAPI.Entities
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }
    }
}
