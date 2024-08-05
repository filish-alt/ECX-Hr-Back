using AutoMapper;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.Contracts.Persistence
{
    public interface IDivisionRepository : IGenericRepository<Divisions>
    {
        //Task<Action<IMappingOperationOptions<object, void>>> GetById(Guid divisionId);
        //Task Update(Action<IMappingOperationOptions<object, void>> division);
    }
}
