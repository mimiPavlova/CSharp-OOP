using BlackFriday.Core.Contracts;
using BlackFriday.Models;
using BlackFriday.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Core
{
    public class Controller : IController
    {
        private IApplication application;
      //  public IApplication Application { get { return application; } }
        public Controller()
        {
            application = new Application();
        }


       
        public string AddProduct(string productType, string productName, string userName, double basePrice)
        {
            //Check product types
            if (productType!="Item"&&productType!="Service")
            {
                return $"{productType} is not a valid type for the application.";
            }
            //Check if product exists
            else if (application.Products.Exists(productName))
            {
                return $"{productName} already exists in the application.";
            }

            IUser ?user = application.Users.GetByName(userName);
            if (user is null)
            {
                return $"{userName} has no data access.";
            }
            if (!user.HasDataAccess)
            {
                return $"{userName} has no data access.";
            }
            IProduct product = null;
            if (productType=="Item")
            {
                product =new Item(productName, basePrice);

            }
            else
            {
                product =new Service(productName, basePrice);
            }
            application.Products.AddNew(product);
            return $"{productType}: {productName} is added in the application. Price: {basePrice:F2}";

        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();
           
            var administrators=application.Users.Models.Where(u=>u.HasDataAccess).OrderBy(a=>a.UserName).ToList();
            sb.AppendLine("Application administration:");
            for (int i = 0; i < administrators.Count; i++)
            {
              sb.AppendLine(administrators[i].ToString());
            }
            
            sb.AppendLine("Clients:");
            var clients=application.Users.Models.Where(c=>!c.HasDataAccess).OrderBy(c=>c.UserName).ToList();
            foreach (Client c in clients)
            {
                sb.AppendLine(c.ToString());
                var blackFridayPercheses = c.Purchases.Where(p => p.Value==true).ToList();
                if (blackFridayPercheses.Count==0) continue;
                sb.AppendLine($"-Black Friday Purchases: {blackFridayPercheses.Count}");
                foreach (var item in blackFridayPercheses)
                {
                    sb.AppendLine("--"+item.Key);
                }
            }

            return sb.ToString().Trim();
        }

        public string PurchaseProduct(string userName, string productName, bool blackFridayFlag)
        {
            if(!application.Users.Exists(userName))
            {
                return $"{userName} has no authorization for this functionality.";
            }
            IUser user = application.Users.GetByName(userName);
            if (application.Users.GetByName(userName).HasDataAccess)
            {
                return $"{userName} has no authorization for this functionality.";
            }
            
             Client ?client=user as Client;  
            if (!application.Products.Exists(productName)) return $"{productName} does not exist in the application.";
           
            IProduct product = application.Products.GetByName(productName);
            if (product.IsSold) return $"{productName} is out of stock.";

            product.ToggleStatus();
            client.PurchaseProduct(productName, blackFridayFlag);
            
            double price=blackFridayFlag?product.BlackFridayPrice:product.BasePrice;
            return $"{userName} purchased {productName}. Price: {price:F2}";
            
              
        }

        public string RefreshSalesList(string userName)
        {
            if (!application.Users.Exists(userName))
            {
                return $"{userName} has no data access.";
            }
            if (!application.Users.GetByName(userName).HasDataAccess)
            {
                return $"{userName} has no data access.";
            }
            var soldProducts = application.Products.Models.Where(p => p.IsSold).ToList();
            foreach (IProduct p in soldProducts)
            {
                p.ToggleStatus();
            }
            return $"{soldProducts.Count} products are listed again.";
        }



        public string RegisterUser(string userName, string email, bool hasDataAccess)
        {

            //Validate user alredy exists

            if (application.Users.Exists(userName))
            {
               return $"{userName} is already registered.";
            }

            //Validate email alredy exists 
            else if(application.Users.Models.Any(u=>u.Email==email))
            {
                return $"{email} is already used by another user.";
            }

            IUser? user = null;
            string output;
       
             
            if (hasDataAccess)
            {

                //Check admins count --this check run only if the current user is Admin
                int aplicationAdmins = application.Users.Models.Count(u => u.HasDataAccess);
                if (aplicationAdmins>=2)
                {
                    return $"The number of application administrators is limited.";
                }

                user=new Admin(userName, email);
                output=$"{user.GetType().Name} {userName} is successfully registered with data access.";
            }
            else
            {
                user=new Client(userName, email);
                output=$"{user.GetType().Name} {userName} is successfully registered.";
            }
    
            //Add new User
            application.Users.AddNew(user);
            //Return
            return output;

        }

        public string UpdateProductPrice(string productName, string userName, double newPriceValue)
        {
            if (!application.Products.Exists(productName)) return $"{productName} does not exist in the application.";
            if(!application.Users.Exists(userName))
            {
                return $"{userName} has no data access.";
            }
            if (!application.Users.GetByName(userName).HasDataAccess)
            {
                return $"{userName} has no data access.";
            }

            IProduct product=application.Products.GetByName(productName);
            double oldPrice = product.BasePrice;
            product.UpdatePrice(newPriceValue);
           
            return $"{productName} -> Price is updated: {oldPrice:F2} -> {newPriceValue:F2}";
        }
    }
}
