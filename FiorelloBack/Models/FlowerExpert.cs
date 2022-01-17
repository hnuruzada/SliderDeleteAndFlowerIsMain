using System.ComponentModel.DataAnnotations;

namespace FiorelloBack.Models
{
    public class FlowerExpert
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        public string Image { get; set; }
        [StringLength(maximumLength: 120)]
        public string Fullname { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
