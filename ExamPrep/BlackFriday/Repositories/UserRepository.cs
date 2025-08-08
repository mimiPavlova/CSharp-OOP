using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> _users;
        public IReadOnlyCollection<IUser> Models => _users.AsReadOnly();
        public UserRepository()
        {
            _users = new List<IUser>();
        }

        public void AddNew(IUser model)
        {
            _users.Add(model);
        }

        public bool Exists(string name)
        {
            return _users.Any(u=>u.UserName == name);
                
        }

        public IUser GetByName(string name)
        {
           return _users.FirstOrDefault(u=>u.UserName == name);
        }
    }
}
