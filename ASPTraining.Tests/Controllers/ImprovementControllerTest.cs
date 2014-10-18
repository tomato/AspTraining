using ASPTraining.Controllers;
using ASPTraining.Models;
using ASPTraining.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;

namespace ASPTraining.Tests.Controllers
{
    [TestClass]
    public class ImprovementControllerTest
    {
        [TestMethod]
        public void Index_ShouldOrderImprovementsByStatus()
        {
            var repos = new Mock<IImprovementsRepository>();
            repos.Setup(r => r.SelectAll()).Returns(
                new List<Improvement>(){
                    new Improvement(){ Id=4, Description= "Done Improvement", Status = new Status(){ Id=3, Description = "Done"}},
                    new Improvement(){ Id=5, Description= "New Improvement", Status = new Status(){ Id=1, Description = "ToDo"}},
                    new Improvement(){ Id=6, Description= "IP Improvement", Status = new Status(){ Id=2, Description = "InProgress"}}
            });

            // Arrange
            ImprovementsController controller = new ImprovementsController(repos.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            var improvements = result.Model as List<Improvement>;


            Assert.AreEqual("New Improvement", improvements[0].Description);
            Assert.AreEqual("IP Improvement", improvements[1].Description);
            Assert.AreEqual("Done Improvement", improvements[2].Description);

        }

    }
}
