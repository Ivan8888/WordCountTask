using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Models;
using Server.Repositories;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private ITextRepository _repository;

        public TextController(ITextRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<TextData> Get()
        {
            TextData result = _repository.GetText();
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }
    }
}