using BarbecueRestApi.Data;
using BarbecueRestApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarbecueRestApi.Services
{
    public class EstablishmentService
    {

        private readonly BarbecueRestApiContext _context;

        public EstablishmentService(BarbecueRestApiContext context)
        {
            _context = context;
        }

        public async Task<List<Establishment>> ListEstablishment()
        {
            var listEstablishment = _context.Establishment.ToListAsync();
            return await listEstablishment;
        }

        public async Task<Establishment> InsertEstablishment(Establishment establishment)
        {
            _context.Add(establishment);
            await _context.SaveChangesAsync();
            return establishment;
        }
    }
}
