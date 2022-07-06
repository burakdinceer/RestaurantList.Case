using System.Collections.Generic;

namespace RestaurantList.Case.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public virtual ICollection<Cafe> cafes { get; set; }
    }
}
