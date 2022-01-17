using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FiorelloBack.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:50)]
        public string Title { get; set; }

        [Required]
        [StringLength(maximumLength: 150)]
        public string SubTitle { get; set; }

        [Required]
        [StringLength(maximumLength: 1000)]
        public string Description { get; set; }

        
        public DateTime DateTime { get; set; }
        public List<BlogImage> BlogImages { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public int BlogCategoryId { get; set; }

    }
}
