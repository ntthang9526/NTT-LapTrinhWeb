namespace MyWebsite.Models
{
    public class ProductFilterViewModel
    {
        public List<Product> Products { get; set; } = new();
        public List<Category> Categories { get; set; } = new();
        public int? SelectedCategoryId { get; set; }
        public string? SearchTerm { get; set; }
        public string? SortOrder { get; set; }
        public int TotalCount { get; set; }
    }
}
