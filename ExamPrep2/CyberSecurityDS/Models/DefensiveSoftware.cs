using CyberSecurityDS.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Models
{
    public abstract class DefensiveSoftware : IDefensiveSoftware
    {
        private string _name;
        private int _effectivness;
        private List<string> _assignedAttacks;
        public string Name
        {
            get
            {
                return _name;
            }
           private  set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.SoftwareNameRequired);
                }
                _name = value;
            }
        }
        public int Effectiveness
        {
            get
            {
                return _effectivness;
            }
            private set
            {
                if (value==0)
                {
                    _effectivness=1;
                }
                else if (value>10)
                {
                    _effectivness=10;
                }
                else if (value<0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.EffectivenessNegative);
                }

                else
                {
                    _effectivness = value;
                }
            }
        }
        public IReadOnlyCollection<string> AssignedAttacks => _assignedAttacks.AsReadOnly();

        public DefensiveSoftware(string name, int effectiveness)
        {
            Name=name;
            Effectiveness=effectiveness;
            _assignedAttacks=new List<string>();
        }

        public void AssignAttack(string attackName)
        {
            _assignedAttacks.Add(attackName);
        }
        public override string ToString()
        {
            string text = string.Join(", ", _assignedAttacks);
            if (_assignedAttacks.Count==0) text= "[None]";
            return $"Defensive Software: {Name}, Effectiveness: {Effectiveness}, Assigned Attacks: {text}";
        } 

    }
}
