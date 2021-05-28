using ImagePick.Application.Contracts.Models;
using ImagePick.Application.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagePick.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>List of Users</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserApplication>>> GetAll()
        {
            try
            {
                var result = await _userService.GetAllAsync();

                return Ok(result);

            }
            catch ( Exception ex)
            {

                return Conflict(ex.Message);

                throw;
            }
        }

        /// <summary>
        /// Get User by Id.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>one User by id</returns>
        /// <response code="200">Returns the User by id</response>
        /// <response code="404">User not found</response>
        /// <response code="409">error in the server</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserApplication>> Get(string id)
        {
            try
            {
                var result = await _userService.GetAsync(id);

                if (result == null)
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
        /// Create a new User
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A newly created User</returns>
        /// <response code="201">Returns the newly created User</response>
        /// <response code="400">If the User is null or model is invalid</response>
        /// <response code="409">error in the server</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
        public async Task<ActionResult<UserApplication>> Post(
            [FromBody] UserApplication model )
        {
            try
            {
                if(!ModelState.IsValid) 
                {
                    return BadRequest(ModelState);
                }

                var result = await _userService.AddAsync(model);

                return Created("", result);

            }
            catch ( Exception ex )
            {

                return Conflict(ex.Message);
                throw;
            }
        }

        /// <summary>
        ///  Edit User
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A edited User</returns>
        /// <response code="201">Returns User edited</response>
        /// <response code="400">If the User is null or model is invalid</response>
        /// <response code="409">error in the server</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPut]
        public async Task<ActionResult<UserApplication>> Put(
            [FromBody] UserApplication model )
        {
            try
            {
                if ( !ModelState.IsValid )
                {
                    return BadRequest(ModelState);
                }

                var result = await _userService.UpdateAsync(model);

                return Created("", result);

            }
            catch ( Exception ex )
            {

                return Conflict(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Delete User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if deleted</returns>
        /// <response code="200">Returns true if deleted successfully</response>
        /// <response code="404">User not found</response>
        /// <response code="409">error in the server</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete( string id )
        {
            try
            {

                var result = await _userService.GetAsync(id);

                if (result == null )
                {
                    return NotFound();
                }

                return Ok(await _userService.DeleteAsync(id));


            }
            catch ( Exception ex )
            {

                return Conflict(ex.Message);
                throw;
            }
        }

    }
}
