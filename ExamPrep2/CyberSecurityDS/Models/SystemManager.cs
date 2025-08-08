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
        private IRepository<ICyberAttack> _attackRepository;

        private IRepository<IDefensiveSoftware> _deffensiveSoftware; 
        public IRepository<ICyberAttack> CyberAttacks => _attackRepository;
        public IRepository<IDefensiveSoftware> DefensiveSoftwares => _deffensiveSoftware;

        public SystemManager()
        {
            _deffensiveSoftware = new DefensiveSoftwareRepository();
            _attackRepository=new CyberAttackRepository();
        }


    }
}
