using BlackFriday.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    public abstract class Product : IProduct

    {
        private string _name;
        private double _basePrice;
        private bool _isSold;
        public double _blackFridayPrise;
        public string ProductName
        {
            get
            {
                return _name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.ProductNameRequired);
                }
                this._name=value;
            }
        }

        public double BasePrice
        {
            get
            {
                return this._basePrice;
            }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.ProductPriceConstraints);
                }
                this._basePrice=value;
            }
        }

        
        public virtual double BlackFridayPrice
        {
            get
            {
                return _blackFridayPrise;
            }
            protected set
            {
                _blackFridayPrise=value;    
            }
    
        }
        public bool IsSold=>_isSold;

        protected Product(string productName, double basePrice)
        {
            _isSold=false;
            ProductName=productName;
            BasePrice=basePrice;
        }

        public void ToggleStatus()
        {
           _isSold=!_isSold; 
        }

        public void UpdatePrice(double newPriceValue)
        {
           this.BasePrice=newPriceValue;
        }

        public override string ToString()
       => $"Product: {ProductName}, Price: {BasePrice:F2}, You Save: {(BasePrice-BlackFridayPrice):F2}";
    }
}
