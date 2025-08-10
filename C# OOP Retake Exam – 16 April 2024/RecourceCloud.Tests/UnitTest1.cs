using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RecourceCloud.Tests
{
    public class DepartmentCloudTests
    {
        private DepartmentCloud departmentCloud;
            string[] data1 = new string[] { "1", "none", "first" };
            string[] data2 = new string[] { "2", "none", "second" };
            string[] data3 = new string[] { "3", "none", "third" };

        [SetUp]
        public void Setup()
        {
            departmentCloud = new DepartmentCloud();    
        }
        [Test]
        public void DepartmentCloudShouldBeInitializedCorrectly()
        {
            Assert.That(departmentCloud.Resources, Is.Not.Null);
            Assert.That(departmentCloud.Resources, Is.Empty);
            Assert.That(departmentCloud.Tasks, Is.Not.Null);
            Assert.That(departmentCloud.Tasks, Is.Empty);
        }

        [Test]
        public void LogTaskShouldWorkCorrectly()
        {
            string result = departmentCloud.LogTask(data1);
            Assert.AreEqual(result, $"Task logged successfully.");
        }

        [Test]
        public void LogTaskShouldReturnErorMessegeIfTaskWithTheSameNameExists()
        {
            departmentCloud.LogTask(data1);
            string result=departmentCloud.LogTask(data1);
            Assert.AreEqual(result, $"first is already logged.");
        }
        [Test]
        public void LogTaskShouldThrowExceptionIfInputWithInvalidLenghtIsProvided()
        {
            string[] ivalidInput = new string[] { "0", "invalide" };
            Assert.That(
                ()=>departmentCloud.LogTask(ivalidInput), Throws.ArgumentException
                );
            
        }
        [Test]
        public void LogTaskShouldThrowAnExceptionIfOneOfTheInputMembersIsNull()
        {
            string[] invalideInput = new string[] { null, "nothing", "nothing" };
            Assert.That(
                () => departmentCloud.LogTask(invalideInput), Throws.ArgumentException);
        }


        [Test]
        public void CreateResourceShould_AddResourseToResourseCollectin_AndRemoveTaskFromTaskCollection()
        {
            departmentCloud.LogTask(data1);
            departmentCloud.LogTask(data2);
            departmentCloud.LogTask(data3);

            bool result = departmentCloud.CreateResource();
            Assert.IsTrue(result);
            var item = departmentCloud.Tasks.FirstOrDefault(t => t.ResourceName=="first");
            Assert.IsNull(item);
            Resource resource = departmentCloud.Resources.FirstOrDefault();
            Assert.IsNotNull(resource);
            Assert.That(!resource.IsTested);
            Assert.AreEqual(resource.ResourceType, "none");
        }
        [Test]
        public void CreateResoureceShouldReturnFalseWhenTaskCollectionIsEmpty()
        {
            Assert.IsFalse(departmentCloud.CreateResource());
        }

        [Test]
        public void TestResourseShouldReturnFalseIfResourseWithThisNameDoesntExist()
        {
            Assert.IsNull(departmentCloud.TestResource("nonExisting"));
        }

        [Test]
        public void TestResourseShouldWorkCorrectly()
        {
            departmentCloud.LogTask(data1);
            departmentCloud.CreateResource();
             Resource resource= departmentCloud.TestResource("first");
            Assert.IsNotNull(resource);
            Assert.AreEqual(resource.Name, "first");
            Assert.IsTrue(resource.IsTested);
        }


       
    }
}
