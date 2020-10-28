using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using testCase.Services;
using testCase.Models;

namespace testCase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolishController : ControllerBase
    {
        private readonly IPolishSolver _polishSolver;

        public PolishController(IPolishSolver polishSolver)
        {
            _polishSolver = polishSolver;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Solve([FromBody]string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return BadRequest();
            }
            var result = _polishSolver.Calculate(data);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}