namespace MyWebsite.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public decimal Price { get; set; }
        public decimal? OriginalPrice { get; set; }
        public string Unit { get; set; } = "Hộp";
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Indications { get; set; } = string.Empty; // Chỉ định điều trị
        public string Usage { get; set; } = string.Empty;       // Cách dùng & liều lượng
        public string Manufacturer { get; set; } = string.Empty; // Nhà sản xuất / Nước xuất xứ
        public bool PrescriptionRequired { get; set; } = false;  // Thuốc kê đơn / Không kê đơn
        public bool IsTopSelling { get; set; } = false;          // Sản phẩm bán chạy
        public int Stock { get; set; } = 100;                    // Số lượng tồn kho
    }
}
