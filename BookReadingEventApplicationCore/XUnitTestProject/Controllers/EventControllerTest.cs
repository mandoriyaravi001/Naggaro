using BookReadingEventApplicationCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject.Controllers
{
    public class EventControllerTest
    {
        // Arrange

        private readonly EventController controller;
        public EventControllerTest(EventController controller)
        {
            this.controller = controller; 
        }
        //check the View Name
        [TestMethod]
        public void Create()
        {
           

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }
    }
}
