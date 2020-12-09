using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service;

        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAll([FromBody] ClienteConsulta cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _service.GetAll(cliente);
        }


        [HttpPost]
        public async Task<ActionResult<Cliente>> Add([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return await _service.Add(cliente);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Cliente>> GetAll(int id)
        {
            return await _service.GetById(id);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult<Cliente>> Update([FromBody] ClienteConsulta cliente, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return await _service.Update(cliente, id);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _service.Delete(id);

        }
    }
}
