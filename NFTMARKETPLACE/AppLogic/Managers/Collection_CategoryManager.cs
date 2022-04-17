using DataAccess.Crud;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.Managers
{
    public class Collection_CategoryManager : BaseManager
    {
        private Collection_CategoryCrudFactory CCM;

        public Collection_CategoryManager()
        {
            CCM = new Collection_CategoryCrudFactory();
        }

        public void CreateCollection_Category(Collection_Category nft)
        {
            CCM.Create(nft);
        }

        public void UpdateCollection_Category(Collection_Category nft)
        {
            CCM.Update(nft);
        }

        public void DeleteCollection_Category(Collection_Category nft)
        {
            CCM.Delete(nft);
        }

        public List<Collection_Category> RetrieveAllCollection_Category()
        {
            return CCM.RetrieveAll<Collection_Category>();
        }
    }
}
