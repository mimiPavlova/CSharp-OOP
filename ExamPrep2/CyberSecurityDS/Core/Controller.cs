using CyberSecurityDS.Core.Contracts;
using CyberSecurityDS.Models;
using CyberSecurityDS.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Core
{
    public class Controller : IController
    {
        private ISystemManager _systemManager;
        public Controller()
        {
            _systemManager=new SystemManager();
        }
        public string AddCyberAttack(string attackType, string attackName, int severityLevel, string extraParam)
        {
            if(attackType !="PhishingAttack"&&attackType!="MalwareAttack")
            {
                return $"{attackType} is not a valid type for the system.";
            }

            if (_systemManager.CyberAttacks.Exists(attackName))
            {
                return $"{attackName} already exists in the system.";
            }
            ICyberAttack attack = null;
            if (attackType=="MalwareAttack")
            {
                attack=new MalwareAttack(attackName, severityLevel, extraParam);
            }
            else if (attackType=="PhishingAttack")
            {
                attack=new PhishingAttack(attackName, severityLevel, extraParam);
            }
            _systemManager.CyberAttacks.AddNew(attack);
            return $"{attackType}: {attackName} is added to the system.";

        }

        public string AddDefensiveSoftware(string softwareType, string softwareName, int effectiveness)
        {
            if (softwareType!="Firewall"&&softwareType!="Antivirus")
            {
                return $"{softwareType} is not a valid type for the system.";
            }
            if (_systemManager.DefensiveSoftwares.Exists(softwareName))
            {
                return $"{softwareName} already exists in the system.";
            }

            IDefensiveSoftware software = null;
            if (softwareType=="Antivirus")
            {
                software=new Antivirus(softwareName, effectiveness);
            }
            else if (softwareType=="Firewall")
            {
                software=new Firewall(softwareName, effectiveness);
            }
            _systemManager.DefensiveSoftwares.AddNew(software);
            return $"{softwareType}: {softwareName} is added to the system.";
        }

        public string AssignDefense(string cyberAttackName, string defensiveSoftwareName)
        {
            if (!_systemManager.CyberAttacks.Exists(cyberAttackName))
            {
                return $"{cyberAttackName} does not exist in the system.";
            }
            if (!_systemManager.DefensiveSoftwares.Exists(defensiveSoftwareName))
            {
                return $"{defensiveSoftwareName} does not exist in the system.";
            }
            ICyberAttack cyberAttack=_systemManager.CyberAttacks.GetByName(cyberAttackName);
            IDefensiveSoftware defensiveSoftware=_systemManager.DefensiveSoftwares.GetByName(defensiveSoftwareName);
            var softwareWithThisAttack = _systemManager.DefensiveSoftwares.Models.FirstOrDefault(s => s.AssignedAttacks.Contains(cyberAttackName));
            if (softwareWithThisAttack!=null)
            {    
                return $"{cyberAttackName} is already assigned to {softwareWithThisAttack.Name}.";
            }
            defensiveSoftware.AssignAttack(cyberAttackName);
                return $"{cyberAttackName} is assigned to {defensiveSoftwareName}.";
        }

        public string GenerateReport()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine("Security:");
            var security=_systemManager.DefensiveSoftwares.Models.OrderBy(s=>s.Name).ToList();
            foreach (var s in security)
            {
                sb.AppendLine(s.ToString());
            }
            sb.AppendLine("Threads:");
            sb.AppendLine("-Mitigated:");
            var mitigated=_systemManager.CyberAttacks.Models.Where(attack=>attack.Status==true).OrderBy(n=>n.AttackName).ToList();
            foreach (var m in mitigated)
            {
                sb.AppendLine(m.ToString());
            }
            sb.AppendLine("-Pending:");
            var pending=_systemManager.CyberAttacks.Models.Where(p=>!p.Status).OrderBy(n=>n.AttackName).ToList();
            foreach(var p in pending)
            {
                sb.AppendLine(p.ToString());
            }
            return sb.ToString();
        }

        public string MitigateAttack(string cyberAttackName)
        {
            if (!_systemManager.CyberAttacks.Exists(cyberAttackName))
            {
                return $"{cyberAttackName} does not exist in the system.";
            }
            ICyberAttack cyberAttack = _systemManager.CyberAttacks.GetByName(cyberAttackName);

            if(cyberAttack.Status)
            {
                return $"{cyberAttackName} is already mitigated.";
            }
            IDefensiveSoftware software =
                _systemManager.DefensiveSoftwares.Models.FirstOrDefault(d => d.AssignedAttacks.Contains(cyberAttackName));
            
            if(software==null)
            {
                return $"{cyberAttackName} is not assigned yet.";
            }

            bool validPair = (software is Firewall&&cyberAttack is MalwareAttack)||
                (software is Antivirus&&cyberAttack is PhishingAttack);
            if (!validPair)
            {
                return $"{software.GetType().Name} cannot mitigate {cyberAttack.GetType().Name}.";
            }
            int effectivness=software.Effectiveness;
            int level=cyberAttack.SeverityLevel;

            if(effectivness>=level)
            {
              cyberAttack.MarkAsMitigated();
              return  $"{cyberAttackName} is mitigated successfully.";
            }
            return $"{cyberAttackName} could not be mitigated by {software.Name}.";



        }
    }
}
