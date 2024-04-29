using lesson1_1.Models;

namespace lesson1_1.Stores
{
    public class ProductDataStore
    {
        public static List<Product> products = new List<Product>()
        {
        new Product{Id = 1, Name="Apple", Description="bu shirin meva", Price=12341.31m},
        new Product{Id = 2, Name="Banana", Description="bu shirin meva", Price=21212},
        new Product{Id = 3, Name="Pineapple", Description="bu shirin meva", Price=434},
        new Product{Id = 4, Name="Tomato", Description="bu achchiq meva", Price=123546541.31m},
        new Product{Id = 5, Name="Potato", Description="bu bu ham meva", Price=768861.31m}
        };

        public List<Product> GetAllProducts() => products;

        public List<Product> GetAllProducts(int id) => products.Where(x=>x.Id==id).ToList();
        
        public Product? GetById(int id)
        {
            var resutl = products.FirstOrDefault(x => x.Id == id);
            return resutl == null ? null : resutl;
        }
        public Product Create(Product product)
        {
            products.Add(product);
            return product;
        }

        public void Update(Product product)
        {
           
            products.Add(product);
        }
        public void Delete(Product product) { products.Remove(product); }
        
    }
}
