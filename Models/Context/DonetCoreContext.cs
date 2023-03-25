using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetCore.Models.Context
{
    public class DonetCoreContext : DbContext
    {
        public DonetCoreContext(DbContextOptions<DonetCoreContext> options) : base(options) { }

        public DbSet<Reserve> Tbl_Reserve { get; set; }
    }
}