using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Repositories
{
    public class CyberAttackRepository : IRepository<ICyberAttack>
    {
        private List<ICyberAttack> _attacks;
        public IReadOnlyCollection<ICyberAttack> Models => _attacks.AsReadOnly();
        public void AddNew(ICyberAttack model)
        {
            _attacks.Add(model);
        }

        public bool Exists(string name)
        {
           return GetByName(name) != null;
        }

        public ICyberAttack GetByName(string name)
        {
            return _attacks.FirstOrDefault(a => a.AttackName==name);
        }
        public CyberAttackRepository()
        {
            _attacks = new List<ICyberAttack>();
        }
    }
}
