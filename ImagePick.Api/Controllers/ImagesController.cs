using ImagePick.Application.Contracts.Models;
using ImagePick.Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class ImagesController : ControllerBase
    {

        private readonly IImageService _imageService;

        public ImagesController( IImageService imageService )
        {
            _imageService = imageService;
        }

        /// <summary>
        /// Get All Images
        /// </summary>
        /// <returns>List of Images</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
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

        /// <summary>
        /// Get Image by Id.
        /// </summary>
        /// <param name="id">Image ID</param>
        /// <returns>one Image by id</returns>
        /// <response code="200">Returns the Image by id</response>
        /// <response code="404">Image not found</response>
        /// <response code="409">error in the server</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageApplication>> Get( string id )
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

        /// <summary>
        /// Create a new Image
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A newly created Image</returns>
        /// <response code="201">Returns the newly created Image</response>
        /// <response code="400">If the Image is null or model is invalid</response>
        /// <response code="409">error in the server</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
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

        /// <summary>
        ///  Edit Image
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A edited Image</returns>
        /// <response code="201">Returns Image edited</response>
        /// <response code="400">If the Image is null or model is invalid</response>
        /// <response code="409">error in the server</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPut]
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

        /// <summary>
        /// Delete Image by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if deleted</returns>
        /// <response code="200">Returns true if deleted successfully</response>
        /// <response code="404">Image not found</response>
        /// <response code="409">error in the server</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete( string id )
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
