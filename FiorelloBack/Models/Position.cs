using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FiorelloBack.Models
{
    public class Position
    {
        public int Id { get; set; }
        [StringLength(maximumLength:60)]
        public string Job { get; set; }
        public List<FlowerExpert> FlowerExperts{ get; set; }
    }
}
