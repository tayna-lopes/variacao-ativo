using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using variacao_ativo.Controllers;
using variacao_ativo.Services.Interface;
using variacao_ativo.Views;

namespace TestProject.Controllers
{
    [TestClass]

    public class VariacaoAtivoControllerTests
    {
        private readonly Mock<ILogger<VariacaoAtivoController>> _loggerMock;
        private readonly Mock<IFinanceApiService> _financeApiServiceMock;
        private readonly VariacaoAtivoController _controller;

        public VariacaoAtivoControllerTests()
        {
            _loggerMock = new Mock<ILogger<VariacaoAtivoController>>();
            _financeApiServiceMock = new Mock<IFinanceApiService>();
            _controller = new VariacaoAtivoController(_loggerMock.Object, _financeApiServiceMock.Object);
        }

        [TestMethod]
        public async Task ObterChart_200ok()
        {
            var variacaoDoAtivoList = new List<VariacaoDoAtivoViewModel>();
            _financeApiServiceMock.Setup(service => service.ObterVariacaoAtivos("PETR4.SA")).ReturnsAsync(variacaoDoAtivoList);

            var result = await _controller.ObterChart("PETR4.SA") as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            var returnedList = result.Value as List<VariacaoDoAtivoViewModel>;
            Assert.IsNotNull(returnedList);
            Assert.AreEqual(variacaoDoAtivoList, returnedList);
        }

        [TestMethod]
        public async Task ObterChart_ParametroNull_BadRequest()
        {
            var result = await _controller.ObterChart(null) as BadRequestResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }
    }
}
