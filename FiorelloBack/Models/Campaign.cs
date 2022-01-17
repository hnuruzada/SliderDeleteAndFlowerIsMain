using System.Collections.Generic;

namespace FiorelloBack.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public int DiscountPercent { get; set; }
        public List<Flower> Flowers { get; set; }
    }
}
