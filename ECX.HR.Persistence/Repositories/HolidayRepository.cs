using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.DTOs.Holiday;
using ECX.HR.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class HolidayRepository : GenericRepository<Holidays>, IHolidayRepository
    {
        private readonly ECXHRDbContext _context;

        public HolidayRepository(ECXHRDbContext context) : base(context)
        {
           _context = context;
        }

            public async Task<List<Holidays>> GetHolidaysFromTable(DateTime startDate, DateTime endDate)
            {
                // Assuming you have a DbSet for holidays named "Holidays" in your DbContext
                var holidays = await _context.Holidays
                    .Where(holiday => holiday.Date >= startDate && holiday.Date <= endDate && holiday.Status == 0)
                    .ToListAsync();

                return holidays;
            }

        }

    }

