using DataAccess.Crud;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.Managers
{
    public class CategoryManager : BaseManager
    {
        private CategoryCrudFactory categoryCrudFactory;

        public CategoryManager()
        {
            categoryCrudFactory = new CategoryCrudFactory();
        }

        public void CreateCategory(Category category)
        {
            categoryCrudFactory.Create(category);
        }

        public void UpdateCategory(Category category)
        {
            categoryCrudFactory.Update(category);
        }

        public void DeleteCategory(Category category)
        {
            categoryCrudFactory.Delete(category);
        }

        public List<Category> RetrieveAll()
        {
            return categoryCrudFactory.RetrieveAll<Category>();
        }
    }
}
