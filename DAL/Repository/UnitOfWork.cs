using DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UnitOfWork
    {
        private readonly ProductListEntities _context;
        public UnitOfWork()
        {
            _context = new ProductListEntities();
        }
        public IProductRepository productRepository
        {
            get
            {
                return new ProductRepository(_context);
            }
        }
        public ICategoryRepository categoryRepository
        {
            get
            {
                return new CategoryRepository(_context);
            }
        }
    }
}
