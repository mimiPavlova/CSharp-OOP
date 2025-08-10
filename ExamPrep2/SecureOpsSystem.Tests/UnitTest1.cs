using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace SecureOpsSystem.Tests
{
    [TestFixture]
    public class SecureHubTests
    {
       
        [TestCase(0), TestCase(-1)]
        public void SecureHubShouldNotBeInstantiatedWithInvalidCapacity(int invalidCapsity)
        {

           Assert.That(
               ()=>new SecureHub(invalidCapsity), 
           Throws.ArgumentException);


        }
        [TestCase(1), TestCase(2), TestCase(10)]
        public void SecureHubShouldBeInstantiatedCorrectly(int validCapacity)
        {
           SecureHub secureHub = new SecureHub(validCapacity);
            Assert.That(secureHub.Capacity, Is.EqualTo(validCapacity));
            Assert.That(secureHub.Tools, Is.Not. Null);
            Assert.That(secureHub.Tools, Is.Empty);
        }
        [TestCase(1), TestCase(5), TestCase(10) ]
        public void AddShouldWorkCorrectly(int capasity)
        {
            SecureHub secureHub = new SecureHub(capasity);
            SecurityTool[]tools=new SecurityTool[capasity];
            for (int i = 0; i <capasity; i++)
            {
                SecurityTool tool = new SecurityTool($"Tool {i+1}", "_", -1);
                tools[i] = tool;
                string result=secureHub.AddTool(tools[i]);
                Assert.AreEqual(result, $"Security Tool {tool.Name} added successfully.");

            }
            Assert.That(secureHub.Tools, Is.EqualTo(tools));

        }
        [TestCase(1), TestCase(5), TestCase(10)]
        public void AddShouldReturnErorIsCapacityIsExceeded(int capasity)
        {
            SecureHub secureHub = new SecureHub(capasity);
            SecurityTool[] tools = new SecurityTool[capasity];
            for (int i = 0; i <capasity; i++)
            {
                SecurityTool tool = new SecurityTool($"Tool {i+1}", "_", -1);
                tools[i] = tool;
                secureHub.AddTool(tools[i]);

            }
            SecurityTool lastTool=new SecurityTool("last", "none", 0);

            string result = secureHub.AddTool(lastTool);
            Assert.AreEqual(result, "Secure Hub is at full capacity.");

            

        }

        [TestCase(1), TestCase(5), TestCase(10)]
        public void AddShouldReturnErorIfToolwithTheSameNameExists(int capasity)
        {
            SecureHub secureHub = new SecureHub(capasity);
           
           
            SecurityTool tool = new SecurityTool($"Tool {1}", "_", -1);
              
            secureHub.AddTool(tool);
            string result = secureHub.AddTool(tool);
            Assert.AreEqual(result, $"Security Tool {tool.Name} already exists in the hub.");

        }
        [TestCase(1), TestCase(5), TestCase(10)]
        public void RemoveToolShouldWorkCorrectly(int capasity)
        {
            SecureHub secureHub = new SecureHub(capasity);
            SecurityTool[] tools = new SecurityTool[capasity];
            for (int i = 0; i <capasity; i++)
            {
                SecurityTool tool = new SecurityTool($"Tool {i+1}", "_", -1);
                tools[i] = tool;
                secureHub.AddTool(tool);

            }

            for (int i = 0; i < capasity; i++)
            {
                bool result = secureHub.RemoveTool(tools[i]);
                Assert.That(result is true );
            }
            Assert.That(secureHub.Tools, Is.Empty);


        }

        [TestCase(1), TestCase(5), TestCase(10)]
        public void RemoveToolShouldReturnFalseIfNotExisted(int capasity)
        {
            SecureHub secureHub = new SecureHub(capasity);
            
            for (int i = 0; i <capasity; i++)
            {
                SecurityTool tool = new SecurityTool($"Tool {i+1}", "_", -1);   
                secureHub.AddTool(tool);

            }

            SecurityTool notAdedTool = new SecurityTool("non_existed", "none", 0);
            bool result=secureHub.RemoveTool(notAdedTool);
            Assert.That(result, Is.False);
        }

        [TestCase(1), TestCase(5), TestCase(10)]
        public void DeployToolShouldWorkCorectly(int capasity)
        {
            SecureHub secureHub = new SecureHub(capasity);
            SecurityTool[] tools = new SecurityTool[capasity];
            for (int i = 0; i <capasity; i++)
            {
                SecurityTool tool = new SecurityTool($"Tool {i+1}", "_", -1);
                secureHub.AddTool(tool);
                tools[i]=tool;

            }
            for (int i = 0; i < capasity; i++)
            {
                SecurityTool tool = secureHub.DeployTool(tools[i].Name);
               Assert.That(tool, Is.Not.Null);
                Assert.That(tool, Is.SameAs(tools[i]));
                bool isStiilInTheHubAfterDeploy = secureHub.RemoveTool(tools[i]);
                Assert.IsFalse(isStiilInTheHubAfterDeploy);
                //Is.SameAs() uses ReferenceEquals(a, b)
            }
        }
        [TestCase(1), TestCase(5), TestCase(10)]
        public void DeployToolShouldReturNullIsNotExisting(int capasity)
        {
            SecureHub secureHub = new SecureHub(capasity);
            SecurityTool[] tools = new SecurityTool[capasity];
            for (int i = 0; i <capasity; i++)
            {
                SecurityTool tool = new SecurityTool($"Tool {i+1}", "_", -1);
                secureHub.AddTool(tool);
                tools[i]=tool;

            }
            SecurityTool nonExisting = secureHub.DeployTool("none_existing");
            Assert.That(nonExisting, Is.Null);
        }
        
        public void  SystemReportShouldBeGeneratedSuccessfullyForEmptyHub()
        {
            SecureHub secure = new SecureHub(5);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Secure Hub Report:");
            sb.AppendLine($"Available Tools: {secure.Tools.Count}");
            Assert.AreEqual(sb.ToString(), secure.SystemReport());

        }
        [Test]
        public void ReportShouldWorkCorrectly()
        {
            SecureHub hub = new SecureHub(3);

            SecurityTool tool1 = new SecurityTool($"Tool {1}", "_", 2.0);
            SecurityTool tool2 = new SecurityTool($"Tool {2}", "_", 3.2);
            SecurityTool tool3= new SecurityTool($"Tool {3}", "_", 4.344);

            hub.AddTool(tool1);
            hub.AddTool(tool2);
            hub.AddTool(tool3);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Secure Hub Report:");
            sb.AppendLine($"Available Tools: {hub.Tools.Count}");
            sb.AppendLine($"Name: {tool3.Name}, Category: {tool3.Category}, Effectiveness: {tool3.Effectiveness:f2}");
            sb.AppendLine($"Name: {tool2.Name}, Category: {tool2.Category}, Effectiveness: {tool2.Effectiveness:f2}");
            sb.AppendLine($"Name: {tool1.Name}, Category: {tool1.Category}, Effectiveness: {tool1.Effectiveness:f2}");
            Assert.AreEqual(sb.ToString().TrimEnd(), hub.SystemReport());
        }
    }
}
