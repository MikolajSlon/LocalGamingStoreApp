﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGSA.Model.ModelWrappers
{
    public class TransactionStatusWrapper : Utility.BindableBase
    {
        private dic_Transaction_status dicTransactionStatus;
        public dic_Transaction_status DicTransactionStatus
        {
            get { return dicTransactionStatus; }
            set { dicTransactionStatus = value; Notify(); }
        }
        public TransactionStatusWrapper(dic_Transaction_status t)
        {
            dicTransactionStatus = t;
            Name = t.name;
            OfferTransactionDescription = t.offer_transaction_description;
        }
        public int Id
        {
            get { return dicTransactionStatus.ID; }
        }
        public string Name
        {
            get { return dicTransactionStatus.name; }
            set { dicTransactionStatus.name = value; Notify(); }
        }
        public string OfferTransactionDescription
        {
            get { return dicTransactionStatus.offer_transaction_description; }
            set { dicTransactionStatus.offer_transaction_description = value; Notify(); }
        }
        public int UpdateWho
        {
            get { return dicTransactionStatus.Update_Who; }
            set { dicTransactionStatus.Update_Who = value; }
        }
        public DateTime UpdateDate
        {
            get { return dicTransactionStatus.Update_Date; }
            set { dicTransactionStatus.Update_Date = value; }
        }
    }
}
