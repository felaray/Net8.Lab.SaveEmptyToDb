using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Net8.Lab.SaveEmptyToDb;

namespace Net8.Lab.SaveEmptyToDb.Data
{
    public class Net8LabSaveEmptyToDbContext : DbContext
    {
        public Net8LabSaveEmptyToDbContext (DbContextOptions<Net8LabSaveEmptyToDbContext> options)
            : base(options)
        {
        }

        public DbSet<Net8.Lab.SaveEmptyToDb.TestModel> TestModel { get; set; } = default!;
    }
}
