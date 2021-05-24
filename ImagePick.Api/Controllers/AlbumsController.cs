using ImagePick.Application.Contracts.Models;
using ImagePick.Application.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagePick.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumsController( IAlbumService albumService )
        {
            _albumService = albumService;
        }

        /// <summary>
        /// Get All Albums
        /// </summary>
        /// <returns>List of Albums</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumApplication>>> GetAll()
        {
            try
            {
                var result = await _albumService.GetAllAsync();

                return Ok(result);

            }
            catch ( Exception ex )
            {

                return Conflict(ex.Message);

                throw;
            }
        }

        /// <summary>
        /// Get Album by Id.
        /// </summary>
        /// <param name="id">Album ID</param>
        /// <returns>one album by id</returns>
        /// <response code="200">Returns the album by id</response>
        /// <response code="404">Album not found</response>
        /// <response code="409">error in the server</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumApplication>> Get( int id )
        {
            try
            {
                var result = await _albumService.GetAsync(id);

                if ( result == null )
                {
                    return NotFound();
                }

                return Ok(result);

            }
            catch ( Exception ex )
            {

                return Conflict(ex.Message);

                throw;
            }
        }

        /// <summary>
        /// Create a new Album
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A newly created Album</returns>
        /// <response code="201">Returns the newly created album</response>
        /// <response code="400">If the album is null or model is invalid</response>
        /// <response code="409">error in the server</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
        public async Task<ActionResult<AlbumApplication>> Post(
            [FromBody] AlbumApplication model )
        {
            try
            {
                if ( !ModelState.IsValid )
                {
                    return BadRequest(ModelState);
                }

                var result = await _albumService.AddAsync(model);

                return Created("", result);

            }
            catch ( Exception ex )
            {

                return Conflict(ex.Message);
                throw;
            }
        }

        /// <summary>
        ///  Edit Album
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A edited Album</returns>
        /// <response code="201">Returns album edited</response>
        /// <response code="400">If the album is null or model is invalid</response>
        /// <response code="409">error in the server</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPut]
        public async Task<ActionResult<AlbumApplication>> Put(
            [FromBody] AlbumApplication model )
        {
            try
            {
                if ( !ModelState.IsValid )
                {
                    return BadRequest(ModelState);
                }

                var result = await _albumService.UpdateAsync(model);

                return Created("", result);

            }
            catch ( Exception ex )
            {

                return Conflict(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Delete Album by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if deleted</returns>
        /// <response code="200">Returns true if deleted successfully</response>
        /// <response code="404">Album not found</response>
        /// <response code="409">error in the server</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete( int id )
        {
            try
            {

                var result = await _albumService.GetAsync(id);

                if ( result == null )
                {
                    return NotFound();
                }

                return Ok(await _albumService.DeleteAsync(id));


            }
            catch ( Exception ex )
            {

                return Conflict(ex.Message);
                throw;
            }
        }
    }
}
