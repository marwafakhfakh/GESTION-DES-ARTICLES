using GESTION_DES_ARTICLES.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GESTION_DES_ARTICLES.Models
{

    public class SqlProductRepository : IRepository<Product>
    {
        private readonly AppDbContext context;

        public SqlProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Product Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public Product Delete(int id)
        {
            Product product = context.Products.Find(id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return product;
        }

        public Product Get(int id)
        {
            return context.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product Update(Product product)
        {
            var entity = context.Products.Attach(product);
            entity.State = EntityState.Modified;
            context.SaveChanges();
            return product;
        }

        // Updated Search method
        public List<Product> Search(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                return context.Products
                              .Where(a => a.Désignation.Contains(term))
                              .ToList();
            }
            else
            {
                return context.Products.ToList();
            }
        }
    }
}