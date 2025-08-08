using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Utilities.Messages;
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
        private int _effectiveness;
        private List<string> _assignedAttacks;
        public string Name 
        {
            get 
            {
                return _name;

            }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.SoftwareNameRequired);
                }
                _name = value;
            }
         }
        public int Effectiveness
        {
            get { return _effectiveness; }

            private set
            {
                if (value==0) _effectiveness = 1;
                else if (value>10) _effectiveness=10;
                else if(value<0)
                {
                    throw new ArgumentException(ExceptionMessages.EffectivenessNegative);

                }
                else
                {
                    _effectiveness = value;
                }
            }
        }
        public IReadOnlyCollection<string> AssignedAttacks => _assignedAttacks.AsReadOnly();

        public override string ToString()
        {
            if (_assignedAttacks.Count==0)
            {
                return $"Defensive Software: {Name}, Effectiveness: {Effectiveness}, Assigned Attacks: [None]";
            }
            return $"Defensive Software: {Name}, Effectiveness: {Effectiveness}, Assigned Attacks: {string.Join(", ", AssignedAttacks)}";
        }

        protected DefensiveSoftware(string name, int effectiveness)
        {
            Name=name;

            Effectiveness=effectiveness;
            _assignedAttacks = new List<string>();
        }

        public void AssignAttack(string attackName)
        {
            _assignedAttacks.Add(attackName);
        }
    }
}
