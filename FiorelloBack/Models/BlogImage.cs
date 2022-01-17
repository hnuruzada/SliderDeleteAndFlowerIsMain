using System.ComponentModel.DataAnnotations;

namespace FiorelloBack.Models
{
    public class BlogImage
    {
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }


        public bool IsMain { get; set; }
        public Blog Blog { get; set; }
        public int BlogId { get; set; }

    }
}
