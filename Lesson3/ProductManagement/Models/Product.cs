using ProductManagement.Models.Enums;

namespace ProductManagement.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }
        public Status ProductStatus { get; set; }
        public DateOnly CreatedAt { get; set; }

        public Product() { }
        public Product(int id, string name, string image, double price, double salePrice, int categoryId, string description, Status status, DateOnly createdAt)
        {
            ID = id;
            Name = name;
            Image = image;
            Price = price;
            SalePrice = salePrice;
            CategoryID = categoryId;
            Description = description;
            ProductStatus = status;
            CreatedAt = createdAt;
        }
        public string GetStatus()
        {
            string text;

            switch (this.ProductStatus) {
                case Status.HetHang:
                    text = "Hết hàng";
                    break;
                case Status.ConHang:
                    text = "Còn hàng";
                    break;
                case Status.NgungKinhDoanh:
                    text = "Ngừng kinh doanh";
                    break;
                default:
                    text = "Không xác định";
                    break;
            }
            return text;
        }
    }
}
