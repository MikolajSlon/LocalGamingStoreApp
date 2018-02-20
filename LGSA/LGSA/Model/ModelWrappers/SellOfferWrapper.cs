﻿using LGSA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGSA.Model.ModelWrappers
{
    public class SellOfferWrapper : Utility.BindableBase
    {
        private sell_Offer sellOffer;
        private ProductWrapper product;
        private UserWrapper seller;
        private OfferStatusWrapper offerStatus;
        private int rating;

        public int Rating { get { return rating; } set { rating = value; Notify(); } }
        public sell_Offer SellOffer
        {
            get { return sellOffer; }
            set { sellOffer = value; Notify(); }
        }
        public SellOfferWrapper(sell_Offer s)
        {
            sellOffer = s;
            Price = (decimal?)s.price;
            Amount = s.amount;
            LastSellDate = s.last_sell_date;
            Name = s.name;
            BoughtCopies = s.buyed_copies;
        }
        public static SellOfferWrapper CreateSellOffer(UserWrapper _user)
        {
            return new SellOfferWrapper(new sell_Offer())
            {
                SellerId = _user.Id,
                UpdateDate = DateTime.Now,
                UpdateWho = _user.Id,
                Product = new ProductWrapper(new product())
                {
                    OwnerId = _user.Id,
                    UpdateDate = DateTime.Now,
                    UpdateWho = _user.Id,
                    Genre = new GenreWrapper(new dic_Genre()),
                    Condition = new ConditionWrapper(new dic_condition()),
                    ProductType = new ProductTypeWrapper(new dic_Product_type())
                },
                StatusId = (int)TransactionState.Created,
            };
        }
        public static SellOfferWrapper CreateSellOffer(sell_Offer s)
        {
            var wrapper = new SellOfferWrapper(s);
            wrapper.Seller = new UserWrapper(s.users);
            wrapper.Product = new ProductWrapper(s.product);
            if (s.product.dic_condition != null)
            {
                wrapper.Product.Condition = new ConditionWrapper(s.product.dic_condition);
            }
            if (s.product.dic_Genre != null)
            {
                wrapper.Product.Genre = new GenreWrapper(s.product.dic_Genre);
            }
            if (s.product.dic_Product_type != null)
            {
                wrapper.Product.ProductType = new ProductTypeWrapper(s.product.dic_Product_type);
            }
            wrapper.UpdateDate = DateTime.Now;
            wrapper.UpdateWho = s.seller_id;
            wrapper.OfferStatus = new OfferStatusWrapper(s.dic_Offer_status);

            return wrapper;
        }
        public int Id
        {
            get { return sellOffer.ID; }
            set { sellOffer.ID = value;  Notify(); }
        }
        public int SellerId
        {
            get { return sellOffer.seller_id; }
            set { sellOffer.seller_id = value; Notify(); }
        }
        public Nullable<decimal> Price
        {
            get { return (decimal?)sellOffer.price; }
            set { sellOffer.price = (double?)value; Notify(); }
        }
        public int Amount
        {
            get { return sellOffer.amount; }
            set { sellOffer.amount = value; Notify(); }
        }
        public Nullable<System.DateTime> LastSellDate
        {
            get { return sellOffer.last_sell_date; }
            set { sellOffer.last_sell_date = value; Notify(); }
        }
        public string Name
        {
            get { return sellOffer.name; }
            set { sellOffer.name = value; Notify(); }
        }
        public int BoughtCopies
        {
            get { return sellOffer.buyed_copies; }
            set { sellOffer.buyed_copies = value; Notify(); }
        }
        public int ProductId
        {
            get { return sellOffer.product_id; }
            set { sellOffer.product_id = value; Notify(); }
        }
        public int StatusId
        {
            get { return sellOffer.status_id; }
            set { sellOffer.status_id = value; Notify(); }
        }
        public int UpdateWho
        {
            get { return sellOffer.Update_Who; }
            set { sellOffer.Update_Who = value; }
        }
        public DateTime UpdateDate
        {
            get { return sellOffer.Update_Date; }
            set { sellOffer.Update_Date = value; }
        }
        public ProductWrapper Product
        {
            get { return product; }
            set
            {
                product = value;
                sellOffer.product = product?.Product;
                Notify();
            }
        }
        public UserWrapper Seller
        {
            get { return seller; }
            set
            {
                seller = value;
                sellOffer.users = seller?.User;
                Notify(); }
        }
        public OfferStatusWrapper OfferStatus
        {
            get { return offerStatus; }
            set
            {
                offerStatus = value;
                sellOffer.dic_Offer_status = offerStatus?.DicOfferStatus;
                Notify();
            }
        }

        public void NullNavigationProperties()
        {
            this.sellOffer.dic_Offer_status = null;
            this.sellOffer.users = null;
            this.sellOffer.users1 = null;
            this.sellOffer.product = null;
        }
    }
}
