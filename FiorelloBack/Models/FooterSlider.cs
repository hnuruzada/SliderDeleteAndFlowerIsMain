using System.ComponentModel.DataAnnotations;

namespace FiorelloBack.Models
{
    public class FooterSlider
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        public string Image { get; set; }
        [StringLength(maximumLength: 500)]
        public string Info { get; set; }
        [StringLength(maximumLength: 70)]
        public string Name { get; set; }
        [StringLength(maximumLength: 20)]
        public string Position { get; set; }
    }
}
