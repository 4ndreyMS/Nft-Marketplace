using DataAccess.Crud;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.Managers
{
    public class CollectionManager : BaseManager
    {

        private CollectionCrud CollectionCF;
        private Collection_CategoryManager CollectionCategory;

        public CollectionManager()
        {
            CollectionCF = new CollectionCrud();
        }

        public NFTCollection CreateCollection(NFTCollection collection)
        {
            CollectionCategory = new Collection_CategoryManager();
            collection.CreationDate = DateTime.Now;
            CollectionCF.Create(collection);
            var retCollName = RetriveCollectionFilterByName(collection);
            CollectionCategory.CreateCollection_Category(new Collection_Category() { IdCollection = retCollName.Id, IdCategory = collection.CategoryId });
            return retCollName;
            /*   var retFilterCollName = RetriveCollectionFilterByName(collection);
               if (retFilterCollName == null)
               {
                   CollectionCF.Create(collection);
                   retFilterCollName = RetriveCollectionFilterByName(collection);
                   return retFilterCollName;
               }
               else
               {
                   retFilterCollName = RetriveCollectionFilterByName(collection);
                   return retFilterCollName;

               }
               return retFilterCollName;*/
        }

        public void UpdateCollection(NFTCollection collection)
        {
            CollectionCF.Update(collection);
        }

        public void DeleteCollection(NFTCollection collection)
        {
            CollectionCF.Delete(collection);
        }

        public NFTCollection RetriveCollectionFilterByName(NFTCollection nftcollection)
        {
            return CollectionCF.RetrieveFilterByName<NFTCollection>(nftcollection);
        }

        public List<NFTCollection> RetrieveAllNFTCollection()
        {
            return CollectionCF.RetrieveAll<NFTCollection>();
        }

        public List<NFTCollection> RetrieveAllCollectionCategory(string category)
        {
            return CollectionCF.RetrieveAllCollectionCategory<NFTCollection>(category);
        }

        public List<CollectionC> RetrieveAllCollectionWithCategory()
        {
            return CollectionCF.RetrieveAllCollectionWithCategory<CollectionC>();
        }

        public List<NFTCollection> RetrieveNFTCollectionCompany(NFTCollection collection)
        {
            return CollectionCF.RetrieveAllNFTCollectionCompany<NFTCollection>(collection);
        }

        public NFTCollection RetrieveCollection(NFTCollection collection)
        {
            return CollectionCF.Retrieve<NFTCollection>(collection);
        }
    }
}