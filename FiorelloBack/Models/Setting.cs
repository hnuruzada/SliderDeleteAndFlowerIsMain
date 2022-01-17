using System.ComponentModel.DataAnnotations;

namespace FiorelloBack.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        public string Logo { get; set; }
        [StringLength(maximumLength: 100)]
        public string SearchIcon { get; set; }
        [StringLength(maximumLength: 100)]
        public string BasketIcon { get; set; }
        [StringLength(maximumLength: 100)]
        public string ParallaxImage { get; set; }
        [StringLength(maximumLength: 150)]

        public string InstagramUrl { get; set; }
        [StringLength(maximumLength: 150)]
        public string FbUrl { get; set; }
    }
}
