using DB_Test_Fox.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DB_Test_Fox.Repository.RoomTypeRepository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly BookingContext _context;

        public RoomTypeRepository(BookingContext context)
        {
            _context = context;
        }

        public async Task<RoomType> AddAsync(RoomType roomType)
        {
            if (roomType == null)
            {
                throw new ArgumentNullException(nameof(roomType));
            }

            _context.RoomTypes.Add(roomType);
            await _context.SaveChangesAsync();

            return roomType;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var roomType = await _context.RoomTypes.FindAsync(id);
            if (roomType == null)
            {
                throw new KeyNotFoundException("No RoomType found with the provided ID.");
            }

            _context.RoomTypes.Remove(roomType);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<RoomType>> GetAllAsync()
        {
            if (_context.RoomTypes == null)
            {
                return null;
            }

            return await _context.RoomTypes.Include(rt => rt.PriceLists).ToListAsync();
        }

        public async Task<RoomType> GetByIdAsync(int id)
        {
            var roomType = await _context.RoomTypes.Include(rt => rt.PriceLists).SingleOrDefaultAsync(a => a.RoomTypeId == id);

            if (roomType == null)
            {
                return null;
            }

            return roomType;
        }

        public async Task<RoomType> UpdateAsync(int id, RoomType updatedRoomType)
        {
            var existingRoomType = await _context.RoomTypes.FindAsync(id);

            if (existingRoomType == null)
            {
                throw new KeyNotFoundException("No Room type found with the provided ID.");
            }

            existingRoomType.Type = updatedRoomType.Type;
            existingRoomType.AccomodationId = updatedRoomType.AccomodationId;

            try
            {
                await _context.SaveChangesAsync();
                return updatedRoomType;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.RoomTypes.Any(e => e.RoomTypeId == id))
                {
                    throw new KeyNotFoundException("No RoomType found with the provided ID.");
                }
                throw;
            }
        }
    }
}
