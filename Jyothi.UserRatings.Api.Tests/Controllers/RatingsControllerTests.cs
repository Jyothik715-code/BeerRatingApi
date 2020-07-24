using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jyothi.UserRatings.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jyothi.UserRatings.Api.Models;
using System.Web.Http;

namespace Jyothi.UserRatings.Api.Controllers.Tests
{
    [TestClass()]
    public class RatingsControllerTests
    {
        [TestMethod()]
        public async void PostTest()
        {
            // Arrange
            RatingsController controller = new RatingsController();

            var input = new UserRatingsModel
            {
                Comments = "Comment1",
                Rating = 7,
                Username = "jyothik715@gmail.com"
            };

            // Act
            IHttpActionResult result = await controller.Post(1, input);

            //    // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(2, result.Count());
            //Assert.AreEqual("Comment1", result.ElementAt(0));
            //Assert.AreEqual("value2", result.ElementAt(1));
        }
    }
}