﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using Markway.Commons.Configurations;

namespace Markway.Users.API.Models
{
    public class UsersContext : DbContext
    {

        private static ISystemConfiguration _systemConfiguration;

        public UsersContext(DbContextOptions<UsersContext> options, SystemConfiguration systemConfiguration) : base(options)
        {
            if (systemConfiguration != null)
            {
                _systemConfiguration = systemConfiguration;
            }
        }

        public UsersContext()
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

        public DbSet<User> Users { get; set; }

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

