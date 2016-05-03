using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PG.Common.Repository;
using PG.DataAccessLayer.Repository;

namespace PG.DataAccessLayerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateUserTestMethod()
        {
            DataAccess data = new DataAccess();
            User user = new User("John", "Snow");
            data.CreateUser(user);
            Assert.AreEqual(data.GetUser("4c668da5-b29a-48c4-a520-0a6b48fe535d").FirstName, "John");
        }
        [TestMethod]
        public void GetUserTestMethod()
        {
            DataAccess data = new DataAccess();
            Assert.AreEqual(data.GetUser("4c668da5-b29a-48c4-a520-0a6b48fe535d").FirstName, "John");
        }

        [TestMethod]
        public void UpdateUserTestMethod()
        {
            User user = new User("Darth", "Vaider");
            DataAccess data = new DataAccess();
            data.UpdateUser("12bbe27c-ffd3-4f2e-be2f-2c48eea5a474", user);
            Assert.AreEqual(data.GetUser("12bbe27c-ffd3-4f2e-be2f-2c48eea5a474").FirstName, "Darth");
            Assert.AreEqual(data.GetUser("12bbe27c-ffd3-4f2e-be2f-2c48eea5a474").LastName, "Vaider");
        }

        [TestMethod]
        public void RemoveUserTestMethod()
        {
            DataAccess data = new DataAccess();
            Assert.IsNotNull(data.GetUser("44bc35f2-ef79-4299-8810-c744ba9c4b8f"));
            data.RemoveUser("44bc35f2-ef79-4299-8810-c744ba9c4b8f");
            Assert.IsNull(data.GetUser("44bc35f2-ef79-4299-8810-c744ba9c4b8f"));
        }
    }
}
