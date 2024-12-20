using Microsoft.AspNetCore.Mvc;
using ParticipantsLib;

namespace RestParticipant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipantController : ControllerBase
    {
        private readonly ParticipantRepository _repo;

        public ParticipantController(ParticipantRepository participantRepository)
        {
            _repo = participantRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var participants = _repo.GetAll();
                return Ok(participants);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving participants.");
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var participant = _repo.GetById(id);
            if (participant == null)
            {
                return NotFound("Participant not found.");
            }
            return Ok(participant);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Add(Participant participant)
        {
            try
            {
                // Validate participant (assuming Validate method throws exceptions for invalid data)
                participant.Validate();

                _repo.Add(participant);
                return CreatedAtAction(nameof(GetById), new { id = participant.Id }, participant);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the participant.");
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var participant = _repo.GetById(id);
            if (participant == null)
            {
                return NotFound("Participant not found.");
            }

            _repo.Delete(id);
            return NoContent();
        }



    }
}
