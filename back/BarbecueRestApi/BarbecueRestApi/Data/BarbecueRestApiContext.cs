using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BarbecueRestApi.Models;

namespace BarbecueRestApi.Data
{
    public class BarbecueRestApiContext : DbContext
    {
        public BarbecueRestApiContext (DbContextOptions<BarbecueRestApiContext> options)
            : base(options)
        {
        }

        public DbSet<BarbecueRestApi.Models.Establishment> Establishment { get; set; }

        public DbSet<BarbecueRestApi.Models.Participant> Participant { get; set; }
    }
}
