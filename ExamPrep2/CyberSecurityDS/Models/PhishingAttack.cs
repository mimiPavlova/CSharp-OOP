using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Models
{
    public class PhishingAttack : CyberAttack
    {
        private string _targetMail;
        public string TargetMail
        {
            get
            {
                return _targetMail;
            }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.TargetMailRequired);

                }
                _targetMail = value;
            }
        }

        public PhishingAttack(string attackName, int severityLevel, string targetMail) : base(attackName, severityLevel)
        {
            TargetMail= targetMail;
        }
        public override string ToString()
            => $"Attack: {AttackName}, Severity: {SeverityLevel} (Target Mail: {TargetMail})";
    }
}
