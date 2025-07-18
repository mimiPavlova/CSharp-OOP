using BlackFriday.Models;
using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Repositories
{
    public class ProductRepository : IRepository<IProduct>
    {
        private List<IProduct> _models;
        public IReadOnlyCollection<IProduct> Models => _models.AsReadOnly();

        public ProductRepository()
        {
            _models = new List<IProduct>();
        }

        public void AddNew(IProduct model)
        {
            _models.Add(model);
        }

        public bool Exists(string name)
        {
            return _models.Any(p=>p.ProductName == name);
        }

        public IProduct GetByName(string name)
        {
           return  _models.FirstOrDefault(p => p.ProductName == name);
        }
    }
}
