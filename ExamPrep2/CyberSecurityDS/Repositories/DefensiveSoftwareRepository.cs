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
        private List<IDefensiveSoftware> _defensiveSoftwareList;
        public IReadOnlyCollection<IDefensiveSoftware> Models => _defensiveSoftwareList.AsReadOnly();

        public void AddNew(IDefensiveSoftware model)
        {
            _defensiveSoftwareList.Add(model);
        }

        public bool Exists(string name)
        {
            return _defensiveSoftwareList.Any(x => x.Name == name);
        }

        public IDefensiveSoftware GetByName(string name)
        {
            return _defensiveSoftwareList.FirstOrDefault(d => d.Name==name);
        }

        public DefensiveSoftwareRepository()
        {
            _defensiveSoftwareList = new List<IDefensiveSoftware>();
        }
    }
}
