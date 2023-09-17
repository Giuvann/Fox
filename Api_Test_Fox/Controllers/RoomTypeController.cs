using Api_Test_Fox.DTOs.RoomTypeDTOs;
using DB_Test_Fox.Models;
using DB_Test_Fox.Repository.RoomTypeRepository;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api_Test_Fox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeController(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        // GET: api/<RoomTypeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomTypeDetailDTO>>> GetRoomTypesAsync()
        {
            var roomTypes = await _roomTypeRepository.GetAllAsync();

            if (roomTypes == null || !roomTypes.Any())
            {
                return NotFound();
            }

            var roomTypesDTO = roomTypes.Adapt<List<RoomTypeDetailDTO>>();

            return Ok(roomTypesDTO);
        }

        // GET api/<RoomTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomTypeDetailDTO>> GetRoomTypeAsync(int id)
        {
            var roomType = await _roomTypeRepository.GetByIdAsync(id);

            if (roomType == null)
            {
                return NotFound();
            }

            var roomTypeDTO = roomType.Adapt<RoomTypeDetailDTO>();

            return Ok(roomTypeDTO);
        }

        // POST api/<RoomTypeController>
        [HttpPost]
        public async Task<ActionResult<RoomTypeCreateDTO>> PostRoomTypeAsync(RoomTypeCreateDTO roomTypeDTO)
        {
            var roomType = roomTypeDTO.Adapt<RoomType>();

            var createdRoomType = await _roomTypeRepository.AddAsync(roomType);

            if (createdRoomType == null)
            {
                return Problem("There was an error while saving the room type.");
            }

            var createdRoomTypeDTO = createdRoomType.Adapt<RoomTypeCreateDTO>();

            return new ObjectResult(createdRoomTypeDTO) { StatusCode = (int)HttpStatusCode.Created };
        }

        // PUT api/<RoomTypeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomTypeAsync(int id, RoomTypeCreateDTO roomTypeDTO)
        {
            var roomType = roomTypeDTO.Adapt<RoomType>();

            try
            {
                var updatedRoomType = await _roomTypeRepository.UpdateAsync(id, roomType);
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

        // DELETE api/<RoomTypeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            try
            {
                var success = await _roomTypeRepository.DeleteAsync(id);
                if (success)
                {
                    return NoContent();
                }
                return BadRequest("Failed to delete the room type.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
