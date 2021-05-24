using ImagePick.Application.Contracts.Models;
using ImagePick.Application.Contracts.Services;
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
