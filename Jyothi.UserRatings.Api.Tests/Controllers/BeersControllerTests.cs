using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jyothi.UserRatings.Api.Data;
using Jyothi.UserRatings.PunkApi.Client;
using Moq;
using Jyothi.UserRatings.Api.Utilities;

namespace Jyothi.UserRatings.Api.Controllers.Tests
{
    [TestClass()]
    public class BeersControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            // Arrange
            BeersController controller = MockControllerCtor();

            //Act
            var results = controller.Get("Mock1");

            //Assert
            Assert.IsNotNull(results.Result);
            Assert.AreEqual("3", ((System.Web.Http.Results.OkNegotiatedContentResult<System.Collections.Generic.List<Jyothi.UserRatings.Api.Models.BeersReviewsModel>>)results.Result).Content.Count.ToString());
            //(new System.Collections.Generic.Mscorlib_CollectionDebugView<Jyothi.UserRatings.Api.Models.BeersReviewsModel>(((System.Web.Http.Results.OkNegotiatedContentResult<System.Collections.Generic.List<Jyothi.UserRatings.Api.Models.BeersReviewsModel>>)results.Result).Content).Items[0]).UserRatings
            //(new System.Collections.Generic.Mscorlib_CollectionDebugView<Jyothi.UserRatings.Api.Models.BeersReviewsModel>(((System.Web.Http.Results.OkNegotiatedContentResult<System.Collections.Generic.List<Jyothi.UserRatings.Api.Models.BeersReviewsModel>>)results.Result).Content).Items[0]).Id
        }

        private static BeersController MockControllerCtor()
        {
            var mockRepository = new Mock<IBeersRepository>();
            mockRepository.Setup(x => x.GetBeersByName("Mock1"))
                .Returns(Task.FromResult(
                    new List<BeerModel> {
                new BeerModel
                {
                    Id = 70,
                    Name = "Mock1Beer1",
                    Description = "Mock1Descrption1"
                },
                new BeerModel
                {
                    Id = 80,
                    Name = "Mock1Beer2",
                    Description = "Mock1Descrption2"
                },
                new BeerModel
                {
                    Id = 90,
                    Name = "Mock1Beer3",
                    Description = "Mock1Descrption3"
                }
            }));

            var mockJson = new Mock<IJsonUtility>();
            mockJson.Setup(x => x.Read("database.json", "Data"))
                .Returns("[{\"Id\":50,\"UserRatings\":{\"Username\":\"Testuser70\",\"Rating\":4,\"Comments\":\"TestComments70\"},\"BeerId\":70}]");

            // Arrange
            BeersController controller = new BeersController(mockRepository.Object, mockJson.Object);
            return controller;
        }
    }
}