using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Models;
using Server.Repositories;
using Microsoft.Extensions.Logging;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private ITextRepository _repository;
        private ILogger<TextController> _logger;

        public TextController(ITextRepository repository, ILogger<TextController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<TextData> Get()
        {
            try
            {
                _logger.LogDebug("Start in get method");
                TextData result = _repository.GetText();
                if(result == null)
                {
                    _logger.LogInformation("There is no text found");
                    return NotFound();
                }

                _logger.LogInformation($"Text found: {result.Id}, {result.Text}");
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex,"Exception while getting text");
                return StatusCode(500, "A problem happend while handling your request");
            }
        }
    }
}