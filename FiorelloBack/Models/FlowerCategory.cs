namespace FiorelloBack.Models
{
    public class FlowerCategory
    {
        public int Id { get; set; }
        public int FlowerId { get; set; }
        public Flower Flower { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
