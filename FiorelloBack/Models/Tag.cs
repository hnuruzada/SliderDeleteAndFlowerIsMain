using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FiorelloBack.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:50,ErrorMessage ="tag adi max 50 karakter olmalidir")]
        public string Name { get; set; }
        public List<FlowerTag> FlowerTags { get; set; }

    }
}
