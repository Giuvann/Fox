using DB_Test_Fox.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DB_Test_Fox.Repository.AccomodationRepository
{
    public class AccomodationRepository : IAccomodationRepository
    {
        private readonly BookingContext _context;

        public AccomodationRepository(BookingContext context)
        {
            _context = context;
        }

        public async Task<Accomodation> AddAsync(Accomodation accomodation)
        {
            if (accomodation == null)
            {
                throw new ArgumentNullException(nameof(accomodation));
            }

            _context.Accomodations.Add(accomodation);
            await _context.SaveChangesAsync();

            return accomodation;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var accomodation = await _context.Accomodations.FindAsync(id);
            if (accomodation == null)
            {
                throw new KeyNotFoundException("No Accomodation found with the provided ID.");
            }

            _context.Accomodations.Remove(accomodation);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Accomodation>> GetAllAsync()
        {
            if (_context.Accomodations == null)
            {
                return null;
            }

            return await _context.Accomodations
                       .Include(a => a.RoomTypes)
                           .Include(a => a.RoomTypes.Select(rt => rt.PriceLists))
                       .ToListAsync();
        }

        public async Task<Accomodation> GetByIdAsync(int id)
        {
            var accomodation = await _context.Accomodations.Include(a => a.RoomTypes)
                .Include(a => a.RoomTypes.Select(rt => rt.PriceLists)).SingleOrDefaultAsync(a => a.AccomodationId == id);

            if (accomodation == null)
            {
                return null;
            }

            return accomodation;
        }

        public async Task<Accomodation> UpdateAsync(int id, Accomodation updatedAccomodation)
        {
            var existingAccomodation = await _context.Accomodations.FindAsync(id);

            if (existingAccomodation == null)
            {
                throw new KeyNotFoundException("No Accomodation found with the provided ID.");
            }

            existingAccomodation.Name = updatedAccomodation.Name;

            try
            {
                await _context.SaveChangesAsync();
                return updatedAccomodation;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Accomodations.Any(e => e.AccomodationId == id))
                {
                    throw new KeyNotFoundException("No Accomodation found with the provided ID.");
                }
                throw;
            }
        }
    }
}
