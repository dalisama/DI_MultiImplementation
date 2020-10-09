using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultiImplementationLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DI_MultiImplementation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {

        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [ActionName("method1")]
        public IActionResult MultiImplementMethod1([FromServices] IEnumerable<IGetData> getDataImplementations)
        {
            var implementation1 = getDataImplementations.FirstOrDefault(x => x.Tag == Keys.A).GetData();
            var implementation2 = getDataImplementations.FirstOrDefault(x => x.Tag == Keys.B).GetData();
            var implementation3 = getDataImplementations.FirstOrDefault(x => x.Tag == Keys.C).GetData();
            return Ok(new List<string> { implementation1, implementation2, implementation3 });
        }
        [HttpGet]
        [ActionName("method2")]
        public IActionResult MultiImplement2([FromServices] Func<Keys, IGetData> getDataFunc)
        {
            var implementation1 = getDataFunc(Keys.A).GetData();
            var implementation2 = getDataFunc(Keys.B).GetData();
            var implementation3 = getDataFunc(Keys.C).GetData();
            return Ok(new List<string> { implementation1, implementation2, implementation3 });
        }

        [HttpGet]
        [ActionName("method3")]
        public IActionResult MultiImplement([FromServices] IGetDataA getDataA, [FromServices] IGetDataB getDataB, [FromServices] IGetDataC getDataC)
        {
            return Ok(new List<string> { getDataA.GetData(), getDataB.GetData(), getDataC.GetData() });
        }

    }
}
