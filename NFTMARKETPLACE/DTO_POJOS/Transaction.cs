
using System;

namespace DTO_POJOS
{
    public class Transaction : BaseEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string TransType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
        public string WalletSend { get; set; }
        public string WalletReceive { get; set; }
        public Wallet Wallet { get; set; }

    }
}
