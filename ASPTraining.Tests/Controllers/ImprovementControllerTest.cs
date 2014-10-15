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
                    new Improvement(){ Id=1, Description= "Hi", Status = Status.InProgress},
                    new Improvement(){ Id=2, Description= "Low", Status = Status.Done},
                    new Improvement(){ Id=1, Description= "No", Status = Status.ToDo}
            });

            // Arrange
            ImprovementsController controller = new ImprovementsController(repos.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            var improvements = result.Model as List<Improvement>;


            Assert.AreEqual(Status.ToDo, improvements[0].Status);
            Assert.AreEqual(Status.InProgress, improvements[1].Status);
            Assert.AreEqual(Status.Done, improvements[2].Status);

        }

    }
}
