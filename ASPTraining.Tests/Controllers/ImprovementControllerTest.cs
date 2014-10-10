using ASPTraining.Controllers;
using ASPTraining.Models;
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
            //object initialisation and lists
            var data = new List<Improvement>(){
                new Improvement(){ Id=1, Description= "Hi", Status = Status.InProgress},
                new Improvement(){ Id=2, Description= "Low", Status = Status.Done},
                new Improvement(){ Id=1, Description= "No", Status = Status.ToDo}
            };

            var set = new Mock<DbSet<Improvement>>()
                .SetupData(data);

            var context = new Mock<ApplicationDbContext>();
            //lambda
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

            //Optional parameters
        }

        [TestMethod]
        public void TestOptionalAndAnonymous()
        {
            //string result = Foo(b: "c");
            //var result =  Foo("f");
            var result = Foo(null, "f");

            Assert.Fail(result);
            
        }

        private string Foo(string a = "a", string b = "b")
        {
            return new { a, b }.ToString();
        }

    }

    public static class StringExtensions
    {
        public static string F(this string input, params string[] args)
        {
            return String.Format(input, args);
        }
    }
}
