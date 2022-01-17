using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FiorelloBack.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:50,ErrorMessage ="Kategoriya adi max 50 olmalidir")]
        public string Name { get; set; }
        public List<FlowerCategory> FlowerCategories { get; set; }
    }
}
