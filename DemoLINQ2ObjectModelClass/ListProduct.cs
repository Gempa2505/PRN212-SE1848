using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLINQ2ObjectModelClass
{
    public class ListProduct
    {
        List<Product> products;
        public ListProduct()
        {
            products = new List<Product>();
        }
        public void gen_products()
        {
            products.Add(new Product() { Id = 1, Name = "P1", Quantity = 20, Price = 100 });
            products.Add(new Product() { Id = 2, Name = "P2", Quantity = 8, Price = 126 });
            products.Add(new Product() { Id = 3, Name = "P3", Quantity = 30, Price = 111 });
            products.Add(new Product() { Id = 4, Name = "P4", Quantity = 7, Price = 123 });
            products.Add(new Product() { Id = 5, Name = "P5", Quantity = 40, Price = 156 });
            products.Add(new Product() { Id = 6, Name = "P6", Quantity = 28, Price = 78 });
            products.Add(new Product() { Id = 7, Name = "P7", Quantity = 16, Price = 87 });
            products.Add(new Product() { Id = 8, Name = "P8", Quantity = 27, Price = 98 });
            products.Add(new Product() { Id = 9, Name = "P9", Quantity = 100, Price = 89 });
            products.Add(new Product() { Id = 10, Name = "P10", Quantity = 78, Price = 150 });
        }
        //Lọc sản phẩm
        public List<Product> FilterProductByPrice(double price1, double price2)
        {
            var result = from p in products
                         where p.Price >= price1 && p.Price <= price2
                         select p;
            return result.ToList();
        }
        public List<Product> FilterProductByPrice2(double price1, double price2)
        {
            return products
                .Where(p => p.Price >= price1 && p.Price <= price2).ToList();
        }

        //Sắp xếp tăng dần
        public List<Product> SortProductsByPriceAsc()
        {
            return products
                .OrderBy(p => p.Price).ToList();
        }
        public List<Product> SortProductsByPriceAsc2()
        {
            var result = from p in products
                         orderby p.Price
                         select p;
            return result.ToList();
        }

        //Sắp xếp giảm dần
        public List<Product> SortProductsByPriceDesc()
        {
            return products
                .OrderByDescending(p => p.Price).ToList();
        }
        public List<Product> SortProductsByPriceDesc2()
        {
            var result = from p in products
                         orderby p.Price descending
                         select p;
            return result.ToList();
        }

        //Tính tổng
        public double SumOfValue()
        {
            return products.Sum(p => p.Price * p.Quantity);
        }

        //Tìm chi tiết sản phẩm
        public Product SearchProDuctDetail(int id)
        {
            //Hàm FirstOrDefault nếu tìm thấy sẽ trả về đối tượng còn ko trả về null
            return products.FirstOrDefault(p => p.Id == id);
        }

        //Hàm lọc ra TOP N sản phẩm có giá trị lớn nhất
        public List<Product>GetTopProducts(int n)
        {
            return products
                .OrderByDescending(p => p.Quantity * p.Price)
                .Take(n).ToList();
        }
    }
}
