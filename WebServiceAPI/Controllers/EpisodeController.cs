using System.Linq;
using AutoMapper;
using Dataservices.Domain.Imdb;
using Dataservices.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebServiceAPI.Models;

namespace WebServiceAPI.Controllers
{
    [Route("api/episode")]
    [ApiController]
    public class EpisodeController : Controller
    {
        //we need the IRepository here for dependency injection
        private readonly IEpisodeRepository _episodeService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;
        
        public EpisodeController(IEpisodeRepository episodeService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _episodeService = episodeService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("cast/{id}")]
        public IActionResult GetEpisodeCast(string id)
        {
            return null;
        }
        
        [HttpGet("crew/{id}")]
         public IActionResult GetEpisodeCrew(string id)
         {
             return null;
         }

         [HttpGet("rating/{id}")]
         public IActionResult GetEpisodeRating(string id)
         {
             return null;
         }
    }
}