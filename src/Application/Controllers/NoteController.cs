using Domain.Entities;
using Domain.Interfaces;
using Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private IBaseService<Note> _baseNoteService;

        public NoteController(IBaseService<Note> baseNoteService)
        {
            _baseNoteService = baseNoteService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Note note)
        {
            if (note == null)
                return NotFound();

            return Execute(() => _baseNoteService.Add<NoteValidator>(note).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Note note)
        {
            if (note == null)
                return NotFound();

            return Execute(() => _baseNoteService.Update<NoteValidator>(note));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseNoteService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseNoteService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseNoteService.GetById(id));
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