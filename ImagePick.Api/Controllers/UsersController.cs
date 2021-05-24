using ImagePick.Application.Contracts.Models;
using ImagePick.Application.Contracts.Services;
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


        [HttpGet("{id}")]
        public async Task<ActionResult<UserApplication>> Get(int id)
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

        [HttpPost]
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

        public async Task<ActionResult<bool>> Delete( int id )
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
