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
        private ILogger<Net8LabSaveEmptyToDbContext> _logger;

        public Net8LabSaveEmptyToDbContext (DbContextOptions<Net8LabSaveEmptyToDbContext> options, ILogger<Net8LabSaveEmptyToDbContext> logger)
            : base(options)
        {
            _logger = logger;
        }

        public DbSet<Net8.Lab.SaveEmptyToDb.TestModel> TestModel { get; set; } = default!;

        //override savechange
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity == null) continue;

                var props = entry.Entity.GetType().GetProperties();

                foreach (var prop in props)
                {
                    //check if string and null,then set to empty
                    if (prop.PropertyType == typeof(string) && prop.GetValue(entry.Entity) == null)
                    {
                        prop.SetValue(entry.Entity, "");
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
