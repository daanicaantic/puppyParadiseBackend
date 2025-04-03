using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class PuppyParadiseContext : DbContext
    { 
        public PuppyParadiseContext(DbContextOptions<PuppyParadiseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
