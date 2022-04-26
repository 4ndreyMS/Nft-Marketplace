using DataAccess.Crud;
using DTO_POJOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.Managers
{
    public class NFTManager : BaseManager
    {
        private NFTCrudFactory nftCF;
        private CollectionCrud collectionCF;
        private CollectionManager collectionManager;
        private NFT_CategoryManager NFTCategoryManager;

        public NFTManager()
        {
            nftCF = new NFTCrudFactory();
        }

        /*public void CreateNFT(NFT nft)
         {
             var cm = new NFTManager();
             var collection = cm.CreateNFTandCollection(nft);
         }*/

        public NFT CreateNFT(NFT nft)
        {
            NFTCategoryManager = new NFT_CategoryManager();
            nft.CreationDate = DateTime.Now;
            nft.IdCreator = nft.IdOwner;
            nft.Id = GenHexaId();
            nftCF.Create(nft);
            NFTCategoryManager.CreateNFT_Category(new NFT_Category() {NFTId = nft.Id, CategoryId = nft.IdCategory});
            return nft;
        }

        public string GenHexaId()
        {
            var byteArray = new byte[(int)Math.Ceiling(10 / 2.0)];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(byteArray);
            }
            return String.Concat(Array.ConvertAll(byteArray, x => x.ToString("X2")));
        }



        public void UpdateNFT(NFT nft)
        {
            nftCF.Update(nft);
        }

        public NFT RetrieveNFT(NFT nft)
        {
            NFT result = new NFT();
            try
            {
                result = nftCF.Retrieve<NFT>(nft);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return result;
        }

        public void DeleteNFT(NFT nft)
        {
            nftCF.Delete(nft);
        }

        public List<NFT> RetrieveAllNFT()
        {
            return nftCF.RetrieveAll<NFT>();
        }

        public List<NFTC> RetrieveAllNFTWithCategory()
        {
            return nftCF.RetrieveAllNFTWithCategory<NFTC>();
        }

        public List<NFT> RetrieveNFTCategory(string category)
        {
            return nftCF.RetrieveAllNFTCategory<NFT>(category);
        }

        public List<NFTC> RetrieveNFTWithOwner()
        {
            return nftCF.RetrieveAllNFTWithOwner<NFTC>();
        }

        public object RetrieveAllNFTInProperty(NFT nft)
        {
            return nftCF.RetrieveAllNFTInProperty<NFT>(nft);
        }
    }
}
