using DB_Test_Fox.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DB_Test_Fox.Repository.PriceListRepository
{
    public class PriceListRepository : IPriceListRepository
    {
        private readonly BookingContext _context;

        public PriceListRepository(BookingContext context)
        {
            _context = context;
        }

        public async Task<PriceList> AddAsync(PriceList priceList)
        {
            if (priceList == null)
            {
                throw new ArgumentNullException(nameof(priceList));
            }

            _context.PriceList.Add(priceList);
            await _context.SaveChangesAsync();

            return priceList;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var priceList = await _context.PriceList.FindAsync(id);
            if (priceList == null)
            {
                throw new KeyNotFoundException("No Price list found with the provided ID.");
            }

            _context.PriceList.Remove(priceList);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<PriceList>> GetAllAsync()
        {
            if (_context.PriceList == null)
            {
                return null;
            }

            return await _context.PriceList.ToListAsync();
        }

        public async Task<PriceList> GetByIdAsync(int id)
        {
            var priceList = await _context.PriceList.FindAsync(id);

            if (priceList == null)
            {
                return null;
            }

            return priceList;
        }

        public async Task<PriceList> UpdateAsync(int id, PriceList updatedPriceList)
        {
            var existingPriceList = await _context.PriceList.FindAsync(id);

            if (existingPriceList == null)
            {
                throw new KeyNotFoundException("No Price list found with the provided ID.");
            }

            existingPriceList.Price = updatedPriceList.Price;
            existingPriceList.AccomodationId = updatedPriceList.AccomodationId;
            existingPriceList.RoomTypeId = updatedPriceList.RoomTypeId;
            existingPriceList.Date = updatedPriceList.Date;

            try
            {
                await _context.SaveChangesAsync();
                return updatedPriceList;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PriceList.Any(e => e.PriceListId == id))
                {
                    throw new KeyNotFoundException("No Price list found with the provided ID.");
                }
                throw;
            }
        }
    }
}
