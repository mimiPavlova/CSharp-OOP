using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories;
using CyberSecurityDS.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Models
{
    public class SystemManager:ISystemManager
    {
        private IRepository<ICyberAttack> _attacks;
        private IRepository<IDefensiveSoftware> _softwares;
        public IRepository<ICyberAttack> CyberAttacks => _attacks;
        public IRepository<IDefensiveSoftware> DefensiveSoftwares => _softwares;

        public SystemManager()
        {
            _attacks=new CyberAttackRepository();
            _softwares=new DefensiveSoftwareRepository();
        }
    }
}
