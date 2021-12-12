using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MHP.CodingChallenge.Backend.Mapping.Data;
using MHP.CodingChallenge.Backend.Mapping.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MHP.CodingChallenge.Backend.Mapping.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private ILogger<ArticleController> _logger;
        private ArticleService _articleService;

        public ArticleController(ILogger<ArticleController> logger,
            ArticleService articleService)
        {
            _logger = logger;
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var articles = _articleService.GetAll();

                return StatusCode(StatusCodes.Status200OK, articles);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<ArticleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(long id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dto = _articleService.GetById(id);

                    if (dto != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, dto);
                    }
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ArticleDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create(ArticleDto article)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dto = _articleService.Create(article);
                    return StatusCode(StatusCodes.Status201Created, dto);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
