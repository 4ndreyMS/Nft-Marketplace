using DataAccess.Crud;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.Managers
{
    public class NFT_CategoryManager : BaseManager
    {
        private NFT_CategoryCrudFactory nftCrud;

        public NFT_CategoryManager()
        {
            nftCrud = new NFT_CategoryCrudFactory();
        }

        public void CreateNFT_Category(NFT_Category nft)
        {
            nftCrud.Create(nft);
        }

        public void UpdateNFT_Category(NFT_Category nft)
        {
            nftCrud.Update(nft);
        }

        public void UpdateNFT_CategoryNFTId(NFT_Category nft)
        {
            nftCrud.UpdateNFTId(nft);
        }

        public void DeleteNFT_Category(NFT_Category nft)
        {
            nftCrud.Delete(nft);
        }

        public List<NFT_Category> RetrieveAllNFT_Category()
        {
            return nftCrud.RetrieveAll<NFT_Category>();
        }
    }
}
