using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Attendance.Request.Command;
using ECX.HR.Application.DTOs.Attendance.Validator;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class AttendanceRepository : GenericRepository<Attendances>, IAttendanceRepository
    {
        private readonly ECXHRDbContext _context;
        private readonly IAttRepository _attRepository;
        DateTime?[] alldates;




        public AttendanceRepository(ECXHRDbContext context,IAttRepository attRepository) : base(context)
        {
            
            _context = context;
            _attRepository = attRepository;
            alldates = _context.Attendances.Select(d => d.ClockIn).ToArray();
        }


        public async Task<List<Attendances>> GetByEmpId(Guid empId)
        {
            return await _context.Set<Attendances>()
                     .Where(T => T.EmpId == empId && T.Status == 0)
                .ToListAsync();
        }
        public async Task<List<CheckInOut>> GetByDate()
        {
            DateTime targetdate = DateTime.Now;
            DateTime? nearstdate  ;
                if (alldates.Length==0)
            {
                nearstdate = DateTime.Parse("2024-01-16 08:34:04.0000000");
            }
            else {

                nearstdate = alldates.OrderByDescending(d => d).FirstOrDefault(d => d < targetdate ).Value.AddDays(1);
                
                     
                }

            return await _attRepository.GetChechInOutByDate(nearstdate);                                                                                                                                                                                                                                                                                                                        
                    
                
        }
      



    }
}
    

