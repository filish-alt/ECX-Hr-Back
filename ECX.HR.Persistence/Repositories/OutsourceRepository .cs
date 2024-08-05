using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.Models;
using ECX.HR.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class OutsourceRepository : GenericRepository<OutSources>, IOutsourceRepository
    {
        private readonly ECXHRDbContext _context;

        public OutsourceRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }
     
     

    }
}