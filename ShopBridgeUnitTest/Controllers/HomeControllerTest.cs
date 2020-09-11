using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBridge.Controllers;
using ShopBridge.Models;
using ShopBridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using System.ComponentModel;
using System.Web;
using System.Web.Routing;

namespace ShopBridgeUnitTest.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        ShopBridgeEntities db = new ShopBridgeEntities();


        

        [TestMethod]
        public void CoponentHomePage()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.CoponentHomePage() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void TestAddComponentForGetMethod()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.AddComponent() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestAddComponentPostMethod()
        {
            Mock<ComponentViewModel> Mockrepo = new Mock<ComponentViewModel>();
            component newComp = new component()
            {
                Name = "BMW",
                Price = 252525,
                Discription = "Long Life Car",
                ID = 1
            };

            var httpContextMock = new Mock<HttpContextBase>();
            var serverMock = new Mock<HttpServerUtilityBase>();
            serverMock.Setup(x => x.MapPath("~/Images/NBAlogoImg/")).Returns("@c:/Users/jadha/source/repos/ShopBridge/ShopBridge/App_Data/");
            httpContextMock.Setup(x => x.Server).Returns(serverMock.Object);
          
            var fileMock = new Mock<HttpPostedFileBase>();
            fileMock.Setup(x => x.FileName).Returns("car3.jfif");


            HomeController controller = new HomeController();
            controller.ControllerContext = new ControllerContext(httpContextMock.Object,new RouteData(),controller);


            //Act
            ActionResult result = controller.AddComponent(newComp, fileMock.Object);

            //assert
            fileMock.Verify(x => x.SaveAs("@c:/Users/jadha/source/repos/ShopBridge/ShopBridge/App_Data/car3.jfif"));
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }




    }
}
