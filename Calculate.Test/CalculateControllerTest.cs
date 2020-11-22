using Calculate.Common.Models;
using Calculate.Service.Interface.Interface;
using CalculatorApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Assert = NUnit.Framework.Assert;

namespace Calculate.Test
{

    public class CalculateControllerTest
    {
        private readonly Mock<ICalculateService> calculateService = new Mock<ICalculateService>();
        private CalculateController calculateController;
        string inputString = "8*2";
        string ipAdress = "127.0.0.1";

        [SetUp]
        public void Setup()
        {
            calculateService.Setup(mock => mock.CalculateValue(inputString, ipAdress).Output);
            calculateController = new CalculateController(calculateService.Object);
        }


        [Test]
        public void TestCalculate()
        {                            
            var expectedResponse = new ApiResult() { Output = "64", Input = "8*8", Error = "" };          
            var response= calculateController.Get(inputString, ipAdress);
            Assert.AreEqual(expectedResponse, response);


        }
    }
}
