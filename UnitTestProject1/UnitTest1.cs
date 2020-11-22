using Calculate.Common.Models;
using Calculate.Service.Interface.Interface;
using CalculatorApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly Mock<ICalculateService> calculateService = new Mock<ICalculateService>();
        private CalculateController calculateController;



        [TestInitialize]
        public void Setup()
        {
            calculateService.Setup(mock => mock.CalculateValue(It.IsAny<string>(),It.IsAny<string>()));
            calculateController = new CalculateController(calculateService.Object);
        }

        [TestMethod]
        public void TestMethod1()
        {
            string inputString = "8*2";
            string ipAdress = "127.0.0.1";
            var expectedResponse = new ApiResult() { Output = "64", Input = "8*8", Error = "" };
            var response = calculateController.Get(inputString, ipAdress);
            Assert.AreEqual(expectedResponse, response);
        }
    }
}
