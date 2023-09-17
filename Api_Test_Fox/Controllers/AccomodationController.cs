using Api_Test_Fox.DTOs.AccomodationDTOs;
using DB_Test_Fox.Models;
using DB_Test_Fox.Repository.AccomodationRepository;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api_Test_Fox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccomodationController : ControllerBase
    {
        private readonly IAccomodationRepository _accomodationRepository;

        public AccomodationController(IAccomodationRepository accomodationRepository)
        {
            _accomodationRepository = accomodationRepository;
        }

        // GET: api/<AccomodationController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccomodationDetailDTO>>> GetAccomodationAsync()
        {
            var accomodations = await _accomodationRepository.GetAllAsync();

            if (accomodations == null || !accomodations.Any())
            {
                return NotFound();
            }

            var accomodationsDTO = accomodations.Adapt<List<AccomodationDetailDTO>>();

            return Ok(accomodationsDTO);

        }

        // GET api/<AccomodationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccomodationDetailDTO>> GetAccomodationById(int id)
        {
            var accomodation = await _accomodationRepository.GetByIdAsync(id);

            if (accomodation == null)
            {
                return NotFound();
            }

            var accomodationDTO = accomodation.Adapt<AccomodationDetailDTO>();

            return Ok(accomodationDTO);
        }

        // POST api/<AccomodationController>
        [HttpPost]
        public async Task<ActionResult<AccomodationCreateDTO>> PostAccomodationAsync(AccomodationCreateDTO accomodationDTO)
        {
            var accomodation = accomodationDTO.Adapt<Accomodation>();

            var createdAccomodation = await _accomodationRepository.AddAsync(accomodation);

            if (createdAccomodation == null)
            {
                return Problem("There was an error while saving the accomodation.");
            }

            var createdAccomodationDTO = createdAccomodation.Adapt<AccomodationCreateDTO>();

            return new ObjectResult(createdAccomodationDTO) { StatusCode = (int)HttpStatusCode.Created };
        }

        // PUT api/<AccomodationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccomodationAsync(int id, AccomodationCreateDTO accomodationDTO)
        {
            var accomodation = accomodationDTO.Adapt<Accomodation>();

            try
            {
                var updatedAccomodation = await _accomodationRepository.UpdateAsync(id, accomodation);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<AccomodationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccomodationAsync(int id)
        {
            try
            {
                var success = await _accomodationRepository.DeleteAsync(id);
                if (success)
                {
                    return NoContent();
                }
                return BadRequest("Failed to delete the accomodation.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
