namespace FiorelloBack.Models
{
    public class FlowerTag
    {

        public int Id { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int FlowerId { get; set; }
        public Flower Flower { get; set; }
    }
}
