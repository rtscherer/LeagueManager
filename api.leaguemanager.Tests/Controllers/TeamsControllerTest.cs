using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueManager.Api;
using LeagueManager.Api.Controllers;
using LeagueManager.Domain;

namespace LeagueManager.Api.Tests.Controllers
{
    [TestClass]
    public class TeamsControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            TeamsController controller = new TeamsController();

            // Act
            IEnumerable<Team> result = controller.GetAllTeams();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            //TeamsController controller = new TeamsController();

            // Act
            //string result = controller.Get(Guid.NewGuid());

            // Assert
            //Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            TeamsController controller = new TeamsController();

            // Act
            controller.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            //TeamsController controller = new TeamsController();

            // Act
            //controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            //TeamsController controller = new TeamsController();

            // Act
            //controller.Delete(5);

            // Assert
        }
    }
}
