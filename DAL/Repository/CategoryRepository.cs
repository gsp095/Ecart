using DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public class CategoryRepository:Repository<CategoryMaster>,  ICategoryRepository
    {
        public CategoryRepository(ProductListEntities _entities) : base(_entities)
        {
        }
    }
}
