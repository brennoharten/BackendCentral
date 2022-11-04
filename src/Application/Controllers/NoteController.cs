using Domain.Entities;
using Domain.Interfaces;
using Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private INoteService _noteService;

        public NoteController(INoteService baseNoteService)
        {
            _noteService = baseNoteService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create([FromBody] Note note)
        {
            if (note == null)
                return NotFound();

            return Execute(() => _noteService.Add<NoteValidator>(note).Id);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] Note note)
        {
            if (note == null)
                return NotFound();

            return Execute(() => _noteService.Update<NoteValidator>(note));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _noteService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Execute(() => _noteService.Get());
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _noteService.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}