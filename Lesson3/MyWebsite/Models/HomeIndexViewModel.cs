using System.Collections.Generic;

namespace MyWebsite.Models
{
    public class HomeIndexViewModel
    {
        public List<Category> Categories { get; set; } = new();
        public List<Product> TopSellingProducts { get; set; } = new();
        public List<Product> FeaturedProducts { get; set; } = new();
    }
}
