using hefth.CQRS.Commands.SectionCommands;
using hefth.CQRS.Queries.SectionQueries;
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
    [Authorize]
    public class SectionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSections()
        {
            var res = await _mediator.Send(new SectionGetQuery());
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddSection(SectionDto sectionDto)
        {
            try
            {
                var res = await _mediator.Send(new SectionInsertCommand(sectionDto));
                return Ok(res);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneSection(int id)
        {
            try
            {
                var res = await _mediator.Send(new SectionGetOneQuery(id));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSection(SectionDto sectionDto, int id)
        {
            try
            {
                var res = await _mediator.Send(new SectionUpdateCommand(sectionDto,id));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            try
            {
                var res = await _mediator.Send(new SectionDeleteCommand(id));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
