using Domain.DTO;
using Infrastructure.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Domain.Views.Notes;
using Domain.Extensions;
using Domain.Views.Users;

namespace Api.Controller
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public sealed class NoteController : ControllerBase
    {
        private readonly ILogger<NoteController> _logger;
        private readonly INoteRepository _repository;

        public NoteController(INoteRepository repository, ILogger<NoteController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NoteView>> GetById(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            var view = entity.ConvertToView();

            return Ok(view);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<NoteView>>> GetAll()
        {
            var entities = await _repository.GetAllAsync();

            List<NoteView> views = new List<NoteView>();
            foreach (var entity in entities)
            {
                views.Add(new NoteView()
                {
                    Id = entity.Id,
                    ListId = entity.ListId,
                    Title = entity.Title,
                });
            }

            return Ok(views);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> Create(CreateNoteView view)
        {
            var model = view.ConvertToEntity();

            var id = await _repository.CreateAsync(model);

            return new ObjectResult(id) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Update(UpdateNoteView view)
        {
            var model = view.ConvertToEntity();

            await _repository.UpdateAsync(model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _repository.RemoveAsync(id);

            return NoContent();
        }
    }
}
