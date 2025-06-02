using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP6_Dictionary
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, Product> Products { get; set; }
        public override string ToString()
        {
            return $"{Id}\t{Name}";
        }
        public Category()
        {
            Products = new Dictionary<int, Product>();
        }
        //Khi quản lý mọi đối tượng phải đáp ứng đầy đủ mọi chức năng CRUD

        public void AddProduct(Product p)
        {
            if (p == null)
            {
                return; //Không thêm sản phẩm null
            }
            if (Products.ContainsKey(p.Id))
            {
                return; //Không thêm sản phẩn đã tồn tại
            }
            //Thêm sản phẩm vào danh sách
            Products.Add(p.Id, p);
        }

        //Xuất toàn bộ sản phẩm
        public void PrintAllProducts()
        {
            foreach (KeyValuePair<int, Product> kvp in Products)
            {
                Product p = kvp.Value;
                Console.WriteLine(p);
            }
        }

        //Lọc tất cả các sản phẩm có giá từ Min tới Max
        public Dictionary<int, Product>
            FilterProductsByPrice(double min, double max)
        {
            return Products.Where(item => item.Value.Price >= min && item.Value.Price <= max).ToDictionary<int, Product>();
        }

        //Sắp xếp sản phẩm theo đơn giá tăng dần
        public Dictionary<int, Product> SortProductByPrice()
        {
            return Products.OrderBy(item => item.Value.Price).ToDictionary<int, Product>();
        }

        public Dictionary<int, Product> SortComplex()
        {
            return Products.OrderByDescending(item => item.Value.Quantity)
                            .OrderBy(item => item.Value.Price).ToDictionary<int, Product>();
        }

        //Sửa thông tin sản phẩm
        public bool updateProduct(Product p)
        {
            if (p == null)
            {
                return false; //null không thể sửa
            }
            if (Products.ContainsKey(p.Id) == false)
            {
                return false;
            }
            //Cập nhật giá trị tại ô nhớ chứa p.Id
            Products[p.Id] = p;
            return true;
        }

        //Xóa sản phẩm
        public bool RemoveProduct(int id)
        {
            if (Products.ContainsKey(id) == false)
            {
                return false; //Không tìm thấy id để xóa
            }
            Products.Remove(id);
            return true;
        }

        //Viết hàm xóa các sản phẩm có mức giá từ a đến b
    }
}
