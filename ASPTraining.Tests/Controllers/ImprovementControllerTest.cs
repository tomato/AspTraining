using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using ASPTraining.Controllers;
using Moq;
using ASPTraining.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace ASPTraining.Tests.Controllers
{
    [TestClass]
    public class ImprovementControllerTest
    {
        [TestMethod]
        public void Index_ShouldOrderImprovementsByStatus()
        {
            var data = new List<Improvement>(){
                new Improvement(){ Id=1, Description= "Hi", Status = Status.InProgress},
                new Improvement(){ Id=2, Description= "Low", Status = Status.Done},
                new Improvement(){ Id=1, Description= "No", Status = Status.ToDo}
            };

            var set = new Mock<DbSet<Improvement>>()
                .SetupData(data);

            var context = new Mock<ApplicationDbContext>();
            context.Setup(c => c.Improvements).Returns(set.Object);

            // Arrange
            ImprovementsController controller = new ImprovementsController(context.Object);

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
