using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebsite.Models
{
    public static class MockRepository
    {
        private static readonly List<Category> _categories;
        private static readonly List<Product> _products;

        static MockRepository()
        {
            _categories = new List<Category>
            {
                new Category { Id = 1, Name = "Thuốc Giảm Đau - Hạ Sốt", Description = "Thuốc điều trị triệu chứng đau đầu, cảm sốt, đau răng", Icon = "bi-capsule-pill" },
                new Category { Id = 2, Name = "Hô Hấp & Tai Mũi Họng", Description = "Siro ho, thuốc xịt mũi họng, kháng khuẩn hô hấp", Icon = "bi-lungs" },
                new Category { Id = 3, Name = "Vitamin & Thực Phẩm Chức Năng", Description = "Bổ sung dưỡng chất, tăng cường đề kháng và năng lượng", Icon = "bi-heart-pulse" },
                new Category { Id = 4, Name = "Tiêu Hóa & Dạ Dày", Description = "Men vi sinh, thuốc dạ dày, đại tràng và hỗ trợ tiêu hóa", Icon = "bi-shield-plus" },
                new Category { Id = 5, Name = "Chăm Sóc Mắt & Vệ Sinh Y Tế", Description = "Nước nhỏ mắt, nước muối sinh lý, dung dịch vệ sinh", Icon = "bi-eye" },
                new Category { Id = 6, Name = "Dụng Cụ Y Tế & Sơ Cứu", Description = "Băng gạc tiệt trùng, nhiệt kế, que thử, khẩu trang y tế", Icon = "bi-bandaid" }
            };

            _products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Panadol Extra Đỏ (Hộp 180 viên)",
                    CategoryId = 1,
                    Price = 195000,
                    OriginalPrice = 220000,
                    Unit = "Hộp 15 vỉ x 12 viên",
                    ImageUrl = "https://images.unsplash.com/photo-1584308666744-24d5c474f2ae?w=600&auto=format&fit=crop&q=80",
                    Description = "Thuốc giảm đau hạ sốt với sự kết hợp của Paracetamol và Caffeine, mang lại hiệu quả giảm đau mạnh mẽ hơn mà không gây buồn ngủ.",
                    Indications = "Điều trị các cơn đau từ nhẹ đến vừa như đau đầu, đau nửa đầu, đau cơ khớp, đau bụng kinh, đau răng và hạ sốt trong các chứng cảm cúm.",
                    Usage = "Người lớn và trẻ em từ 12 tuổi trở lên: Uống 1 - 2 viên mỗi 4 - 6 giờ khi cần thiết. Không dùng quá 8 viên trong vòng 24 giờ. Uống cùng một ly nước đầy.",
                    Manufacturer = "GSK (GlaxoSmithKline) - Anh Quốc",
                    PrescriptionRequired = false,
                    IsTopSelling = true,
                    Stock = 120
                },
                new Product
                {
                    Id = 2,
                    Name = "Viên sủi Efferalgan 500mg Paracetamol",
                    CategoryId = 1,
                    Price = 72000,
                    OriginalPrice = 80000,
                    Unit = "Hộp 4 vỉ x 4 viên sủi",
                    ImageUrl = "https://images.unsplash.com/photo-1577401239170-897942555fb3?w=600&auto=format&fit=crop&q=80",
                    Description = "Viên nén sủi bọt hòa tan nhanh trong nước, hấp thu cấp tốc vào cơ thể giúp hạ nhiệt độ cơ thể và giảm cơn đau khó chịu.",
                    Indications = "Hạ sốt, giảm đau cho các trường hợp sốt phát ban, sốt xuất huyết (theo dõi), đau đầu, đau nhức cơ thể khi cảm mạo cúm mùa.",
                    Usage = "Hòa tan hoàn toàn 1 viên vào cốc nước khoảng 150ml - 200ml, uống ngay sau khi tan hết bọt. Khoảng cách giữa các lần uống tối thiểu 4 giờ.",
                    Manufacturer = "UPSA SAS - Pháp",
                    PrescriptionRequired = false,
                    IsTopSelling = true,
                    Stock = 85
                },
                new Product
                {
                    Id = 3,
                    Name = "Siro Ho Thảo Dược Prospan 100ml",
                    CategoryId = 2,
                    Price = 135000,
                    OriginalPrice = 150000,
                    Unit = "Chai 100ml kèm cốc đong",
                    ImageUrl = "https://images.unsplash.com/photo-1631549916768-4119b2e5f926?w=600&auto=format&fit=crop&q=80",
                    Description = "Chiết xuất độc quyền từ lá thường xuân tự nhiên theo tiêu chuẩn chất lượng châu Âu, an toàn cho trẻ sơ sinh và cả gia đình.",
                    Indications = "Viêm đường hô hấp cấp có kèm theo ho, điều trị triệu chứng trong các bệnh lý viêm phế quản mạn tính, ho có đờm, ho rát cổ họng.",
                    Usage = "Trẻ sơ sinh và trẻ nhỏ (1 - 5 tuổi): 2.5ml/lần, 3 lần/ngày. Trẻ em (6 - 9 tuổi): 5ml/lần, 3 lần/ngày. Người lớn: 5 - 7.5ml/lần, 3 lần/ngày. Lắc đều trước khi dùng.",
                    Manufacturer = "Engelhard Arzneimittel - CHLB Đức",
                    PrescriptionRequired = false,
                    IsTopSelling = true,
                    Stock = 60
                },
                new Product
                {
                    Id = 4,
                    Name = "Xịt Mũi Kháng Khuẩn Otrivin 0.05% Trẻ Em",
                    CategoryId = 2,
                    Price = 58000,
                    OriginalPrice = 65000,
                    Unit = "Lọ xịt 10ml",
                    ImageUrl = "https://images.unsplash.com/photo-1628771065518-0d82f1938462?w=600&auto=format&fit=crop&q=80",
                    Description = "Dung dịch xịt mũi chứa Xylometazoline hydrochloride giúp co mạch niêm mạc mũi, thông thoáng đường thở tức thì chỉ sau 2 phút.",
                    Indications = "Nghẹt mũi do cảm lạnh, viêm mũi dị ứng theo mùa, viêm xoang. Giúp dẫn lưu chất nhầy ứ đọng ở các xoang bị viêm.",
                    Usage = "Trẻ em từ 1 - 5 tuổi: Xịt 1 lần vào mỗi bên lỗ mũi, 1 - 2 lần mỗi ngày. Không dùng liên tục quá 7 ngày.",
                    Manufacturer = "GSK Consumer Healthcare - Thụy Sĩ",
                    PrescriptionRequired = false,
                    IsTopSelling = false,
                    Stock = 45
                },
                new Product
                {
                    Id = 5,
                    Name = "Viên sủi Berocca Performance Vị Cam",
                    CategoryId = 3,
                    Price = 210000,
                    OriginalPrice = 235000,
                    Unit = "Tuýp 2 x 10 viên sủi",
                    ImageUrl = "https://images.unsplash.com/photo-1550572017-edd951aa8f72?w=600&auto=format&fit=crop&q=80",
                    Description = "Sự kết hợp hoàn hảo giữa Vitamin nhóm B, Vitamin C, Canxi, Magie và Kẽm giúp tinh thần tỉnh táo, giải tỏa mệt mỏi và nâng cao năng lượng.",
                    Indications = "Người cần bổ sung vi chất dinh dưỡng do chế độ ăn thiếu hụt, người làm việc trí óc căng thẳng, học sinh sinh viên ôn thi mệt mỏi.",
                    Usage = "Mỗi ngày dùng 1 viên sủi, hòa tan trong một ly nước (200ml). Uống vào buổi sáng để đạt hiệu quả sảng khoái suốt ngày dài.",
                    Manufacturer = "Bayer AG - CHLB Đức",
                    PrescriptionRequired = false,
                    IsTopSelling = true,
                    Stock = 150
                },
                new Product
                {
                    Id = 6,
                    Name = "Dầu Cá Blackmores Fish Oil 1000mg Không Mùi",
                    CategoryId = 3,
                    Price = 380000,
                    OriginalPrice = 450000,
                    Unit = "Lọ 400 viên nang mềm",
                    ImageUrl = "https://images.unsplash.com/photo-1584017911766-d451b3d0e843?w=600&auto=format&fit=crop&q=80",
                    Description = "Nguồn cung cấp Omega-3 tự nhiên tinh khiết từ cá biển sâu, hỗ trợ thị lực sáng khỏe, não bộ minh mẫn và ổn định huyết áp.",
                    Indications = "Hỗ trợ bảo vệ tim mạch, giảm triglyceride máu, nuôi dưỡng võng mạc mắt, làm dịu khô mắt và thoái hóa điểm vàng.",
                    Usage = "Người lớn: Uống 2 viên mỗi ngày sau bữa ăn. Để hỗ trợ xương khớp: Uống tối đa 4 viên/ngày chia 2 lần hoặc theo chỉ dẫn chuyên gia y tế.",
                    Manufacturer = "Blackmores - Úc (Australia)",
                    PrescriptionRequired = false,
                    IsTopSelling = true,
                    Stock = 90
                },
                new Product
                {
                    Id = 7,
                    Name = "Men Vi Sinh Enterogermina 4 Tỷ Bào Tử",
                    CategoryId = 4,
                    Price = 185000,
                    OriginalPrice = 205000,
                    Unit = "Hộp 20 ống x 5ml",
                    ImageUrl = "https://images.unsplash.com/photo-1471864190281-a93a3070b6de?w=600&auto=format&fit=crop&q=80",
                    Description = "Chứa hàng tỷ bào tử Bacillus clausii kháng đa kháng sinh, giúp phục hồi hệ vi sinh đường ruột bị tổn thương nhanh chóng.",
                    Indications = "Điều trị và phòng ngừa rối loạn vi sinh đường ruột và bệnh lý kém hấp thu vitamin nội sinh. Phục hồi đường ruột sau khi dùng kháng sinh.",
                    Usage = "Trẻ nhỏ: 1 - 2 ống/ngày. Người lớn: 2 - 3 ống/ngày. Lắc đều trước khi bẻ nắp uống trực tiếp hoặc pha loãng với nước, sữa, nước cam.",
                    Manufacturer = "Sanofi-Aventis - Ý (Italia)",
                    PrescriptionRequired = false,
                    IsTopSelling = true,
                    Stock = 110
                },
                new Product
                {
                    Id = 8,
                    Name = "Hỗn Dịch Uống Dạ Dày Gaviscon Dual Action",
                    CategoryId = 4,
                    Price = 165000,
                    OriginalPrice = 180000,
                    Unit = "Hộp 24 gói x 10ml",
                    ImageUrl = "https://images.unsplash.com/photo-1587854692152-cbe660dbde88?w=600&auto=format&fit=crop&q=80",
                    Description = "Công thức tác động kép: tạo lớp màng bọt bảo vệ ngăn acid trào ngược lên thực quản và trung hòa acid dịch vị dư thừa tức thì.",
                    Indications = "Trào ngược dạ dày thực quản (GERD), ợ nóng sau bữa ăn, ợ chua, đau rát tức ngực do thừa acid dạ dày, khó tiêu đầy bụng.",
                    Usage = "Người lớn và trẻ em từ 12 tuổi trở lên: Uống 10 - 20ml (1 - 2 gói) sau các bữa ăn chính và trước khi đi ngủ, tối đa 4 lần mỗi ngày.",
                    Manufacturer = "Reckitt Benckiser - Anh Quốc",
                    PrescriptionRequired = false,
                    IsTopSelling = false,
                    Stock = 75
                },
                new Product
                {
                    Id = 9,
                    Name = "Nước Muối Sinh Lý Kháng Khuẩn Physiodose",
                    CategoryId = 5,
                    Price = 140000,
                    OriginalPrice = 160000,
                    Unit = "Hộp 40 tép x 5ml",
                    ImageUrl = "https://images.unsplash.com/photo-1583947215259-38e31be8751f?w=600&auto=format&fit=crop&q=80",
                    Description = "Dung dịch nước muối biển tinh khiết đẳng trương 0.9% vô trùng, dạng tép tiện dụng dùng một lần, an toàn tuyệt đối cho trẻ sơ sinh.",
                    Indications = "Vệ sinh hàng ngày hốc mũi, rửa trôi bụi bẩn và dịch nhầy ở mắt và mũi, làm sạch vết xước da nhẹ cho cả gia đình.",
                    Usage = "Mở nắp tép bằng cách xoay nhẹ đầu. Nhỏ 1 - 3 giọt vào mỗi bên mắt hoặc mũi, từ 1 - 6 lần mỗi ngày tùy theo nhu cầu làm sạch.",
                    Manufacturer = "Laboratoires Gilbert - Pháp",
                    PrescriptionRequired = false,
                    IsTopSelling = false,
                    Stock = 200
                },
                new Product
                {
                    Id = 10,
                    Name = "Nước Nhỏ Mắt Giảm Mỏi Khô Mắt Systane Ultra",
                    CategoryId = 5,
                    Price = 98000,
                    OriginalPrice = 110000,
                    Unit = "Lọ 10ml",
                    ImageUrl = "https://images.unsplash.com/photo-1585435557343-3b092031a831?w=600&auto=format&fit=crop&q=80",
                    Description = "Nước mắt nhân tạo tiên tiến giúp làm dịu và phục hồi bề mặt nhãn cầu, dưỡng ẩm kéo dài cho người ngồi máy tính nhiều.",
                    Indications = "Làm giảm tạm thời cảm giác cay rát, cộm ngứa, kích ứng do khô mắt khi làm việc với màn hình điện tử, tiếp xúc gió bụi, máy lạnh.",
                    Usage = "Lắc kỹ trước khi dùng. Nhỏ 1 hoặc 2 giọt vào mắt bị khô hoặc kích ứng khi có nhu cầu. Đậy kín nắp sau khi sử dụng.",
                    Manufacturer = "Alcon Laboratories - Hoa Kỳ (USA)",
                    PrescriptionRequired = false,
                    IsTopSelling = true,
                    Stock = 95
                },
                new Product
                {
                    Id = 11,
                    Name = "Hộp Băng Dán Vết Thương Urgo Waterproof Chống Nước",
                    CategoryId = 6,
                    Price = 52000,
                    OriginalPrice = 60000,
                    Unit = "Hộp 30 miếng nhiều kích thước",
                    ImageUrl = "https://images.unsplash.com/photo-1603398938378-e54eab446dde?w=600&auto=format&fit=crop&q=80",
                    Description = "Màng film trong suốt co giãn chống thấm nước tuyệt đối, bảo vệ vết xước, vết rách nhỏ không bị nhiễm trùng khi tắm rửa bơi lội.",
                    Indications = "Bảo vệ và ngăn ngừa vi khuẩn xâm nhập vào các vết cắt nông, trầy xước nhỏ, vết kim tiêm sau chích thuốc.",
                    Usage = "Làm sạch và lau khô vết thương. Dán băng sao cho phần gạc kháng dính che trọn miệng vết thương. Thay băng ít nhất 2 lần/ngày.",
                    Manufacturer = "Urgo Healthcare - Pháp",
                    PrescriptionRequired = false,
                    IsTopSelling = false,
                    Stock = 180
                },
                new Product
                {
                    Id = 12,
                    Name = "Nhiệt Kế Điện Tử Đo Trán Hồng Ngoại Microlife NC200",
                    CategoryId = 6,
                    Price = 850000,
                    OriginalPrice = 990000,
                    Unit = "Hộp 1 máy kèm bao da & pin",
                    ImageUrl = "https://images.unsplash.com/photo-1584515979956-d9f6e5d09982?w=600&auto=format&fit=crop&q=80",
                    Description = "Thiết bị đo nhiệt độ không tiếp xúc hiện đại Thụy Sĩ, đo tự động khi khoảng cách phù hợp trong 3cm với độ chính xác chuẩn lâm sàng.",
                    Indications = "Đo thân nhiệt nhanh chóng chỉ 1 giây cho trẻ nhỏ và người lớn, đo nhiệt độ sữa, nước tắm bé và nhiệt độ môi trường.",
                    Usage = "Đặt đầu dò hướng vào giữa trán ở khoảng cách dưới 3cm. Nhấn nút START hoặc để máy tự kích hoạt khi đèn chỉ dẫn xanh báo đúng cự ly.",
                    Manufacturer = "Microlife AG - Thụy Sĩ",
                    PrescriptionRequired = false,
                    IsTopSelling = true,
                    Stock = 35
                }
            };

            // Map categories to products and update product counts
            foreach (var category in _categories)
            {
                var count = _products.Count(p => p.CategoryId == category.Id);
                category.ProductCount = count;
            }

            foreach (var product in _products)
            {
                product.Category = _categories.FirstOrDefault(c => c.Id == product.CategoryId);
            }
        }

        public static List<Category> GetCategories() => _categories;

        public static List<Product> GetProducts() => _products;

        public static Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public static List<Product> GetTopSellingProducts(int count = 4)
        {
            return _products.Where(p => p.IsTopSelling).Take(count).ToList();
        }

        public static List<Product> GetRelatedProducts(int categoryId, int excludeProductId, int count = 4)
        {
            return _products
                .Where(p => p.CategoryId == categoryId && p.Id != excludeProductId)
                .Take(count)
                .ToList();
        }

        public static List<Product> FilterProducts(int? categoryId, string? search, string? sortOrder)
        {
            var query = _products.AsEnumerable();

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim().ToLower();
                query = query.Where(p =>
                    p.Name.ToLower().Contains(term) ||
                    p.Description.ToLower().Contains(term) ||
                    p.Indications.ToLower().Contains(term) ||
                    p.Manufacturer.ToLower().Contains(term));
            }

            query = sortOrder switch
            {
                "price_asc" => query.OrderBy(p => p.Price),
                "price_desc" => query.OrderByDescending(p => p.Price),
                "name_asc" => query.OrderBy(p => p.Name),
                "bestseller" => query.OrderByDescending(p => p.IsTopSelling).ThenBy(p => p.Price),
                _ => query.OrderBy(p => p.Id)
            };

            return query.ToList();
        }
    }
}
