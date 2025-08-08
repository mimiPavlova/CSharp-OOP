using CyberSecurityDS.Core.Contracts;
using CyberSecurityDS.Models;
using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityDS.Core
{
    public class Controller : IController
    {
        private ISystemManager _manager;
        public Controller() => _manager=new SystemManager();

        public string AddCyberAttack(string attackType, string attackName, int severityLevel, string extraParam)
        {
            if (_manager.CyberAttacks.Exists(attackName))
            { 
                return string.Format(OutputMessages.EntryAlreadyExists, attackName);
            }
                  
            ICyberAttack cyberAttack = null;

            if (attackType=="PhishingAttack")
            {
               cyberAttack=new PhishingAttack(attackName, severityLevel, extraParam);
            }
            else if (attackType=="MalwareAttack")
            {
                cyberAttack=new MalwareAttack(attackName, severityLevel, extraParam);
            }
            else
            {
                return string.Format(OutputMessages.TypeInvalid, attackType);
            }
            _manager.CyberAttacks.AddNew(cyberAttack);
            return string .Format(OutputMessages.EntryAddedSuccessfully, attackType, attackName);
            
        }

        public string AddDefensiveSoftware(string softwareType, string softwareName, int effectiveness)
        {
            if (_manager.DefensiveSoftwares.Exists(softwareName))
            {
                return string.Format (OutputMessages.EntryAlreadyExists, softwareName);
            }

            IDefensiveSoftware defensiveSoftware = null;
            if (softwareType=="Firewall")
            {
                defensiveSoftware=new Firewall(softwareName, effectiveness);
            }
            else if (softwareType=="Antivirus")
            {
                defensiveSoftware=new Antivirus(softwareName, effectiveness);
            }
            else
            {
                return string.Format(OutputMessages.TypeInvalid, softwareType);
            }
            _manager.DefensiveSoftwares.AddNew(defensiveSoftware);
            return string.Format(OutputMessages.EntryAddedSuccessfully, softwareType, softwareName);
        }

        public string AssignDefense(string cyberAttackName, string defensiveSoftwareName)
        {
           
            ICyberAttack cyberAttack=_manager.CyberAttacks.GetByName(cyberAttackName);
            IDefensiveSoftware defensiveSoftware=_manager.DefensiveSoftwares.GetByName(defensiveSoftwareName);
            if(cyberAttack is null)
            {
                return string.Format(OutputMessages.EntryNotFound, cyberAttackName);
            }
            if(defensiveSoftware is null)
            {
                return string.Format(OutputMessages.EntryNotFound, defensiveSoftwareName);
            }

            IDefensiveSoftware conflictSoftware=_manager.DefensiveSoftwares.Models.FirstOrDefault(d=>d.AssignedAttacks.Contains(cyberAttackName));

            if (conflictSoftware !=null)
            {

                return string.Format(OutputMessages.AttackAlreadyAssigned, cyberAttackName, conflictSoftware.Name);
            }
            defensiveSoftware.AssignAttack(cyberAttackName);
            return string.Format(OutputMessages.AttackAssignedSuccessfully, cyberAttackName, defensiveSoftwareName);

        }

        public string GenerateReport()
        {
            var softwares=_manager.DefensiveSoftwares.Models.OrderBy(s=>s.Name).ToList();
            StringBuilder sb = new StringBuilder();
            sb.Append($"Security:");

            foreach (var software in softwares)
            {
                sb.AppendLine();
                sb.Append(software.ToString());
            }
            sb.AppendLine();
            sb.AppendLine("Threads:");

            sb.Append("-Mitigated");
            var mitigated=_manager.CyberAttacks.Models.Where(c=>c.Status).OrderBy(a=>a.AttackName).ToList();
            foreach ( var attack in mitigated )
            {
                sb.AppendLine();
                sb.Append(attack.ToString());
            }
            sb.AppendLine();
            sb.Append("-Pending");
            var pending = _manager.CyberAttacks.Models.Where(c => !c.Status).OrderBy(a=>a.AttackName).ToList();
            foreach (var attack in pending)
            {
                sb.AppendLine();
                sb.Append(attack.ToString());
            } 
            return sb.ToString();
        }

        public string MitigateAttack(string cyberAttackName)
        {
           ICyberAttack cyberAttack=_manager.CyberAttacks.GetByName(cyberAttackName);
           
            if(cyberAttack is null)
            {
                return string.Format(OutputMessages.EntryNotFound, cyberAttackName);
            }
            if(cyberAttack.Status==true)
            {
                return string.Format(OutputMessages.AttackAlreadyMitigated, cyberAttackName);
            }


            IDefensiveSoftware? software = _manager.DefensiveSoftwares.Models.
                   FirstOrDefault(d => d.AssignedAttacks.Contains(cyberAttackName));

            if (software is null)
            {
                return string.Format(OutputMessages.AttackNotAssignedYet, cyberAttackName);
            }

            
            if((software is Firewall&&cyberAttack is MalwareAttack)||(software is Antivirus&&cyberAttack is PhishingAttack))
            {
                if (cyberAttack.SeverityLevel<=software.Effectiveness)
                {
                    cyberAttack.MarkAsMitigated();

                    return string.Format(OutputMessages.AttackMitigatedSuccessfully, cyberAttackName);
                }
                else
                {
                    return string.Format(OutputMessages.SoftwareNotEffectiveEnough, cyberAttackName, software.Name);
                   
                }
            }
            else
            {
                 return string.Format(OutputMessages.CannotMitigateDueToCompatibility, software.GetType().Name,cyberAttack.GetType().Name);
            }
        }
    }
}
