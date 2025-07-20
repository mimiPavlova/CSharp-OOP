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

        public CyberAttackRepository()
        {
            _attacks = new List<ICyberAttack>();
        }
        public void AddNew(ICyberAttack model)
        {
           _attacks.Add(model);
        }

        public bool Exists(string name)
        {
            ICyberAttack attack = _attacks.FirstOrDefault(a => a.AttackName==name);
            return attack!=null; ;
        }

        public ICyberAttack GetByName(string name)
        {
            return _attacks.FirstOrDefault(a => a.AttackName==name);
        }
    }
}
