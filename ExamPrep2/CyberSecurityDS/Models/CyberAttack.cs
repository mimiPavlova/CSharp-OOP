using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Models
{
    public abstract class CyberAttack : ICyberAttack
    {
        private string _attackName;
        private int _severityLevel;
        public string AttackName 
        {
            get
            {
                return _attackName;
            }
            private set 
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CyberAttackNameRequired);
                }
                _attackName = value;
            }

        }
        public int SeverityLevel
        { 
            get 
            { 
                return _severityLevel;
            }
            private set
            {
                if (value==0) _severityLevel=1;
                else if (value>10) _severityLevel=10;
                else if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.SeverityLevelNegative); 
                }
                else
                {
                    _severityLevel = value;
                }
            }
        }
        public bool Status
        {
            get; private set;
        }
        public void MarkAsMitigated()
        {
            Status=true;
        }

        protected CyberAttack(string attackName, int severityLevel)
        {
            AttackName=attackName;
            SeverityLevel=severityLevel;
        }
    }
}
