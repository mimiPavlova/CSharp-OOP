using BlackFriday.Models.Contracts;
using BlackFriday.Repositories;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    public class Application:IApplication
    {
        public IRepository<IUser> users;
        private IRepository<IProduct> products;

        public Application()
        {
            users=new UserRepository();
            products=new ProductRepository();
        }
        public IRepository<IProduct> Products => products;
        public IRepository<IUser> Users => users;
    }
}
