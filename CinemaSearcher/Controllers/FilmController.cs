using AutoMapper;
using CinemaSearcher.Business.Interfaces;
using CinemaSearcher.Business.Searching;
using CinemaSearcher.Models;
using CinemaSearcher.Persisted.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSearcher.Controllers
{
    [Route("api/film")]
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly IMapper _mapper;

        public FilmController(IFilmService filmService, IMapper mapper)
        {
            _filmService = filmService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get specific ticket.
        /// </summary>
        /// <param name="filmId">Ticket Id.</param>
        /// <returns>Place by id.</returns>
        /// <response code="404">If ticket is not found.</response>
        [HttpGet]
        [Route("{filmId}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(Guid filmId)
        {
            var ticket = await _filmService.GetAsync(filmId);

            return Ok(ticket);
        }

        /// <summary>
        /// Get all tickets.
        /// </summary>
        /// <returns>All tickets.</returns>
        /// <response code="404">If tickets are not found.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAll()
        {
            var films = await _filmService.GetAllAsync();

            return Ok((films));
        }

        /// <summary>
        /// Get all tickets by search query.
        /// </summary>
        /// <returns>All tickets by search query.</returns>
        /// <response code="404">If tickets are not found.</response>
        [HttpGet]
        [Route("/api/film/search")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllBySearchQuery([FromQuery] FilmSearchModel filmSearchModel)
        {
            FilmSearchBuilder filmSearchBuilder = new FilmSearchBuilder(FilmSearchModel.Ensure(filmSearchModel));
            var tickets = await _filmService.Find(filmSearchBuilder.Build());

            return Ok(tickets);
        }

        /// <summary>
        /// Add new film.
        /// </summary>
        /// <param name="filmModel">Film.</param>
        /// <returns>A newly created film.</returns>
        /// <response code="200">Returns the newly created film.</response>
        /// <response code="400">If request data is null.</response>
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post(FilmModel filmModel)
        {
            var film = _mapper.Map<Film>(filmModel);
            var createdFilm = await _filmService.AddAsync(film);

            return Ok(createdFilm);
        }

        /// <summary>
        /// Update film.
        /// </summary>
        /// <param name="filmId">Film Id.</param>
        /// <returns>Updated film.</returns>
        /// <response code="200">Returns the updated film.</response>
        /// <response code="400">If request data is null.</response>
        /// <response code="404">If film is not found.</response>
        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Route("{filmId}")]
        public async Task<IActionResult> Put(Guid filmId, FilmModel filmModel)
        {
            var film = await _filmService.GetAsync(filmId);
            _mapper.Map(filmModel, film);
            var updatedFilm = await _filmService.UpdateAsync(filmId, film);

            return Ok(updatedFilm);
        }

        /// <summary>
        /// Delete film.
        /// </summary>
        /// <param name="filmId">Film Id.</param>
        /// <returns></returns>
        /// <response code="204">Returns no content status code.</response>
        /// <response code="404">If film is not found.</response>
        [HttpDelete]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(404)]
        [Route("{filmId}")]
        public async Task<IActionResult> Delete(Guid filmId)
        {
            await _filmService.RemoveAsync(filmId);

            return NoContent();
        }
    }
}
