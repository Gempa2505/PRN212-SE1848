using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Repositories;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository iRepository;
        public ProductService()
        {
            iProductRepositoty = new ProductRepository();
        }
        public void GenerateSampleDataset()
        {
            iRepository.GenerateSampleDataset();
        }

        public List<Product> GetProducts()
        {
            return iRepository.GetProducts();
        }

        public bool SaveProduct(Product product)
        {
            return iRepository.SaveProduct(product);
        }
    }
}
