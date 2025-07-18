using BlackFriday.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    public abstract class User : IUser
    {
        private string _userName;
        
        public string _email;
        public string UserName
        {
            get { return _userName; }
           private  set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.UserNameRequired);
                }
                _userName = value;
            }
        }

        public  bool HasDataAccess { get; protected set; }

        public string Email
        {
            get
            {
                return _email;
            }
            private set
            {
                if (HasDataAccess)
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException(Utilities.Messages.ExceptionMessages.EmailRequired);
                    }
                    _email = value;
                }
                else
                {
                    _email="hidden";
                }
            }
            
        }

        protected User(string userName,  string email,bool hasDataAccess)
        {
            UserName=userName;
            HasDataAccess=hasDataAccess;
            Email=email;
        }

        public override string ToString()
        => $"{UserName} - Status: {this.GetType().Name}, Contact Info: {this.Email}";	
    }
}