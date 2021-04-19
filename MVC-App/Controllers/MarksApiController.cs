using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksApiController : ControllerBase
    {
        private readonly IBaseRepo<MarksModel> _context;

        public MarksApiController(IBaseRepo<MarksModel> context)
        {
            this._context = context;
        }

        // GET: api/<MarksController>
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.GetAll());
        }

        // GET api/<MarksController>/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var studentModel = await _context.Get(id);
            if (studentModel == null)
            {
                return null;
            }

            return Ok(studentModel);
        }

        // POST api/<MarksController>
        [HttpPost("Post/{marksModel}")]
        public async Task<IActionResult> Post(MarksModel marksModel)   //create
        {
            if (ModelState.IsValid)
            {
                await _context.Insert(marksModel);
                return Ok();
            }
            return BadRequest(marksModel);
        }

        // PUT api/<MarksController>/5
        [HttpPut("Put/{marksModel}")]
        public async Task<IActionResult> Put(MarksModel marksModel)    //edit
        {
            if (string.IsNullOrEmpty(marksModel.ID))
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _context.Update(marksModel);
                return Ok(marksModel);
            }
            return BadRequest();
        }

        // DELETE api/<MarksController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentModel = await _context.Get(id);
            if (studentModel == null)
            {
                return NotFound();
            }
            await _context.Delete(id);
            return Ok();
        }
    }
}
