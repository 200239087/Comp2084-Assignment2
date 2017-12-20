using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Web.Mvc;
using Comp2084_Assignment2.Controllers;
using Moq;
using Comp2084_Assignment2.Models;
using System.Linq;

namespace Comp2084_Assignment2.Tests.Controllers
{
    [TestClass]
    public class GamesControllerTest
    {
        GamesController controller;
        Mock<IGamesRepository> mock;
        List<game> games;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IGamesRepository>();

            games = new List<game>
            {
                new game { id = 1, title = "Game 1", company = "Company 1", rating = "E", console = new console { id = 1, name = "Console 1"}},
                new game { id = 2, title = "Game 2", company = "Company 2", rating = "T", console = new console { id = 2, name = "Console 2"}},
                new game { id = 3, title = "Game 3", company = "Company 3", rating = "M", console = new console { id = 3, name = "Console 3"}}
            };

            mock.Setup(m => m.Games).Returns(games.AsQueryable());

            controller = new GamesController(mock.Object);
        }

        // Index 

        [TestMethod]
        public void IndexLoadsValid()
        {
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexLoadValidGames()
        {
            // Act
            var actual = (List<game>)controller.Index().Model;

            //Assert
            CollectionAssert.AreEqual(games, actual);
        }

        // Details

        [TestMethod]
        public void DetailsValidGame()
        {
            // Act
            var actual = (game)controller.Details(1).Model;

            //Assert
            Assert.AreEqual(games.ToList()[0], actual);
        }

        [TestMethod]
        public void DetailsInvalidId()
        {
            // Act
            ViewResult actual = controller.Details(4);

            // Assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DetailsInvalidNoId()
        {
            // Act
            ViewResult actual = controller.Details(null);

            // Assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        // Delete POST

        [TestMethod]
        public void DeleteConfirmedNoId()
        {
            // Act
            ViewResult actual = controller.DeleteConfirmed(null);

            // Assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedInvalidId()
        {
            // Act
            ViewResult actual = controller.DeleteConfirmed(4);

            // Assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedValidId()
        {
            // Act
            ViewResult actual = controller.DeleteConfirmed(1);

            // Assert
            Assert.AreEqual("Index", actual.ViewName);
        }
    }
}
