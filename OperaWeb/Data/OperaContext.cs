using Microsoft.EntityFrameworkCore;
using OperaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperaWeb.Data
{
    public class OperaContext : DbContext
    {
        public OperaContext(DbContextOptions<OperaContext> options) : base(options)
        {
        }

        public DbSet<Opera> Operas { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
