using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jyothi.UserRatings.Api.Models;
using System.Web.Http;
using Moq;
using Jyothi.UserRatings.Api.Data;
using Jyothi.UserRatings.PunkApi.Client;
using Jyothi.UserRatings.Api.Utilities;

namespace Jyothi.UserRatings.Api.Controllers.Tests
{
    [TestClass()]
    public class RatingsControllerTests
    {
        [TestMethod()]
        public void PostTest()
        {
            //Arrange
            RatingsController controller = MockControllerCtor();

            var input = new UserRatingsModel
            {
                Comments = "Comment1",
                Rating = 7,
                Username = "jyothik715@gmail.com"
            };

            // Act
            Task<IHttpActionResult> result = controller.Post(42, input);

            //    // Assert
            Assert.IsNotNull(result.Result);
            Assert.AreEqual(2, ((System.Web.Http.Results.OkNegotiatedContentResult<Data.Entities.RatingsEntity>)result.Result).Content.Id);
            Assert.AreEqual(42, ((System.Web.Http.Results.OkNegotiatedContentResult<Data.Entities.RatingsEntity>)result.Result).Content.BeerId);
        }

        private static RatingsController MockControllerCtor()
        {
            var mockRepository = new Mock<IBeersRepository>();
            mockRepository.Setup(x => x.GetBeer(42))
                .Returns(Task.FromResult(
                    new List<BeerModel> {
                new BeerModel
                {
                    Id = 42,
                    Name = "TestBeer1",
                    Description = "Descrption1"
                }
            }));

            var mockJson = new Mock<IJsonUtility>();
            mockJson.Setup(x => x.Read("database.json", "Data"))
                .Returns("[{\"Id\":1,\"UserRatings\":{\"Username\":\"Testuser2\",\"Rating\":4,\"Comments\":\"TestCommebts\"},\"BeerId\":42}]");

            //mockJson.Setup(x => x.Write("database.json", "Data", "[{\"Id\":1,\"UserRatings\":{\"Username\":\"Testuser2\",\"Rating\":4,\"Comments\":\"TestCommebts\"},\"BeerId\":42}]"))
            //    .Returns(null);

            // Arrange
            RatingsController controller = new RatingsController(mockRepository.Object, mockJson.Object);
            return controller;
        }
    }
}