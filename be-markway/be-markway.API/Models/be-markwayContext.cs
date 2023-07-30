// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using Napokon.Commons.Configurations;

namespace Napokon.be_markway.API.Models
{
    public class be_markwayContext : DbContext
    {

        private static ISystemConfiguration _systemConfiguration;

        public be_markwayContext(DbContextOptions<be_markwayContext> options, SystemConfiguration systemConfiguration) : base(options)
        {
            if (systemConfiguration != null)
            {
                _systemConfiguration = systemConfiguration;
            }
        }

        public be_markwayContext()
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            IEnumerable<EntityEntry> entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Entity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (EntityEntry entityEntry in entries)
            {
                ((Entity)entityEntry.Entity).DateUpdated = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((Entity)entityEntry.Entity).DateCreated = DateTime.UtcNow;
                    ((Entity)entityEntry.Entity).Deleted = false;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<ExampleEntity> Entities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseNpgsql(_systemConfiguration.DatabaseConnection);
        }
    }
}

