using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2BIceTask1
{
    public class Transaction
    {
        public Transaction(int transactionId, DateTime transAction, Product transactionProduct, int transactionQty, double transactionTotal)
        {
            TransactionId = transactionId;
            TransAction = transAction;
            TransactionProduct = transactionProduct;
            TransactionQty = transactionQty;
            TransactionTotal = transactionTotal;
        }

        public int TransactionId { get; set; }
        public DateTime TransAction { get; set; }
        public Product TransactionProduct { get; set; }
        public int TransactionQty { get; set; }
        public double TransactionTotal { get; set; }
    }
}
