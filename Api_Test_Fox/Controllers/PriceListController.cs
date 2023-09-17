using Api_Test_Fox.DTOs.AccomodationDTOs;
using Api_Test_Fox.DTOs.PriceListDtos;
using Api_Test_Fox.DTOs.PriceListDTOs;
using DB_Test_Fox.Models;
using DB_Test_Fox.Repository.PriceListRepository;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api_Test_Fox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceListController : ControllerBase
    {
        private readonly IPriceListRepository _priceListRepository;

        public PriceListController(IPriceListRepository priceListRepository)
        {
            _priceListRepository = priceListRepository;
        }

        // GET: api/<PriceListController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriceListDetailDTO>>> GetPriceListAsync()
        {
            var priceList = await _priceListRepository.GetAllAsync();

            if (priceList == null || !priceList.Any())
            {
                return NotFound();
            }

            var priceListDTO = priceList.Adapt<List<PriceListDetailDTO>>();

            return Ok(priceListDTO);
        }

        // GET api/<PriceListController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PriceListDetailDTO>> GetPriceListAsync(int id)
        {
            var priceList = await _priceListRepository.GetByIdAsync(id);

            if (priceList == null)
            {
                return NotFound();
            }

            var priceListDTO = priceList.Adapt<AccomodationDetailDTO>();

            return Ok(priceListDTO);
        }

        // POST api/<PriceListController>
        [HttpPost]
        public async Task<ActionResult<PriceListCreateDTO>> PostPriceListAsync(PriceListCreateDTO priceListDTO)
        {
            var priceList = priceListDTO.Adapt<PriceList>();

            var createdPriceList = await _priceListRepository.AddAsync(priceList);

            if (createdPriceList == null)
            {
                return Problem("There was an error while saving the price list.");
            }

            var createdPriceListDTO = createdPriceList.Adapt<PriceListCreateDTO>();

            return new ObjectResult(createdPriceListDTO) { StatusCode = (int)HttpStatusCode.Created };
        }

        // PUT api/<PriceListController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriceListAsync(int id, PriceListCreateDTO priceListDTO)
        {
            var priceList = priceListDTO.Adapt<PriceList>();

            try
            {
                var updatedPriceList = await _priceListRepository.UpdateAsync(id, priceList);
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

        // DELETE api/<PriceListController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePriceListAsync(int id)
        {
            try
            {
                var success = await _priceListRepository.DeleteAsync(id);
                if (success)
                {
                    return NoContent();
                }
                return BadRequest("Failed to delete the price list.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
