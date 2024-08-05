﻿using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class LevelRepository : GenericRepository<Levels>, ILevelRepository
    {
        private readonly ECXHRDbContext _context;

        public LevelRepository(ECXHRDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
