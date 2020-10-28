using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using testCase.Models;
using testCase.Services;

namespace testCase.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IDataStorage _dataStorage;
        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger, IDataStorage dataStorage)
        {
            _logger = logger;
            _dataStorage = dataStorage;
        }

        [HttpGet]
        [Route("[action]")]
        public List<Book> Get()
        {
            return _dataStorage.GetAllBooks();
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetSorted(string param)
        {
            if (param == "name")
            {
                return Ok(_dataStorage.GetSortedByName());
            }
            if (param == "year")
            {
                return Ok(_dataStorage.GetSortedByYear());
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(Book book)
        {
            if (!_dataStorage.CreateBook(book))
            {
                return BadRequest("Book already exists");
            }
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(Book book)
        {
            if (book.Id == null)
            {
                return BadRequest();
            }
            if (!_dataStorage.UpdateBook(book))
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            if (!_dataStorage.RemoveBook(id))
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Cover(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            return Ok(_dataStorage.GetCover(id));
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddCover(Cover data)
        {
            if (string.IsNullOrWhiteSpace(data.Id))
            {
                return BadRequest();
            }
            if (!_dataStorage.AddCover(data.Id, data.CoverBase64String))
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult Teapot()
        {
            return StatusCode(418);
        }
    }
}
