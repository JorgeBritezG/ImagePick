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
    public class ImagesController : ControllerBase
    {

        private readonly IImageService _imageService;

        public ImagesController( IImageService imageService )
        {
            _imageService = imageService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageApplication>>> GetAll()
        {
            try
            {
                var result = await _imageService.GetAllAsync();

                return Ok(result);

            }
            catch ( Exception ex )
            {

                return Conflict(ex.Message);

                throw;
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ImageApplication>> Get( int id )
        {
            try
            {
                var result = await _imageService.GetAsync(id);

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
        public async Task<ActionResult<ImageApplication>> Post(
            [FromBody] ImageApplication model )
        {
            try
            {
                if ( !ModelState.IsValid )
                {
                    return BadRequest(ModelState);
                }

                var result = await _imageService.AddAsync(model);

                return Created("", result);

            }
            catch ( Exception ex )
            {

                return Conflict(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<ImageApplication>> Put(
            [FromBody] ImageApplication model )
        {
            try
            {
                if ( !ModelState.IsValid )
                {
                    return BadRequest(ModelState);
                }

                var result = await _imageService.UpdateAsync(model);

                return Created("", result);

            }
            catch ( Exception ex )
            {

                return Conflict(ex.Message);
                throw;
            }
        }

        public async Task<ActionResult<bool>> Delete( int id )
        {
            try
            {

                var result = await _imageService.GetAsync(id);

                if ( result == null )
                {
                    return NotFound();
                }

                return Ok(await _imageService.DeleteAsync(id));


            }
            catch ( Exception ex )
            {

                return Conflict(ex.Message);
                throw;
            }
        }

    }
}
