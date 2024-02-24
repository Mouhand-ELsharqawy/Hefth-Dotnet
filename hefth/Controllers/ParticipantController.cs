using hefth.CQRS.Commands.ParticipantCommands;
using hefth.CQRS.Queries.ParticipantQueries;
using hefth.data.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hefth.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ParticipantController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ParticipantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetParticipant()
        {
            var res = await _mediator.Send(new ParticipantGetQuery());
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddParticipant(ParticipantDto participantDto)
        {
            try
            {
                var res = await _mediator.Send(new ParticipantInsertCommand(participantDto));
                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneParticipant( int id)
        {
            try
            {
                var res = await _mediator.Send(new ParticipantGetOneQuery(id));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParicipant( ParticipantDto participantDto, int id)
        {
            try
            {
                var res = await _mediator.Send(new ParticipantUpdateCommand(participantDto, id));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            try
            {
                var res = await _mediator.Send(new ParticipantDeleteCommand(id));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
