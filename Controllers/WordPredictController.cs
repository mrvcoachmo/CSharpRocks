using CSharpRocks.Repositories;
using CSharpRocks.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CSharpRocks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordPredictController : ControllerBase
    {
        private readonly iWordPredictService _wordPredictService;


        public WordPredictController(iWordPredictService wordPredictService)
        {
            _wordPredictService = wordPredictService;
        }

        [HttpGet]
        public IActionResult Get(string text, string? token = "", string? locale = "")
        {
            if(string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("text");
            }

            if(string.IsNullOrEmpty(token) && string.IsNullOrEmpty(locale))
            {
                return Ok(_wordPredictService.GetWordsFromDictionary(text));

               
            }

            return Ok(_wordPredictService.GetWordsFromServiceAsync(text, token, locale));
        }
 
    }
}
