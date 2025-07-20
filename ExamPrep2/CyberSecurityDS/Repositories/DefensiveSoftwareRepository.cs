using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Repositories
{
    public class DefensiveSoftwareRepository : IRepository<IDefensiveSoftware>
    {
        private List<IDefensiveSoftware> _software;
        public IReadOnlyCollection<IDefensiveSoftware> Models => _software.AsReadOnly();

        public DefensiveSoftwareRepository()
        {
            _software= new List<IDefensiveSoftware>();
        }
        public void AddNew(IDefensiveSoftware model)
        {
            _software.Add(model);
        }

        public bool Exists(string name)
        {
            IDefensiveSoftware software = _software.FirstOrDefault(s=>s.Name==name);
            return software!=null;
        }

        public IDefensiveSoftware GetByName(string name)
        {
            return _software.FirstOrDefault(s => s.Name==name);
        }
    }
}
