using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using Practice.Api.Database.Contact;

namespace Practice.Api.Database
{
    public sealed class PracticeApiContext : DbContext
    {
        public PracticeApiContext(DbContextOptions<PracticeApiContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Practice.Api.Database.Contact.Contact> Contacts { get; set; }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entityTypeConfiguration = typeof(IEntityTypeConfiguration<>);
            var methodInfo =
            typeof(ModelBuilder).GetMethods().Where(x => x.Name == nameof(ModelBuilder.ApplyConfiguration)).ToList()
                    .Single(x => x.Name == nameof(ModelBuilder.ApplyConfiguration) &&
                                 x.GetParameters().First().ParameterType.Name == entityTypeConfiguration.Name);

            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(c => c.IsClass && !c.IsAbstract && !c.ContainsGenericParameters);

            foreach (Type type in types)
            {
                var entityConfiguration = type.GetInterfaces().SingleOrDefault(i =>
                    i.IsConstructedGenericType && i.GetGenericTypeDefinition() == entityTypeConfiguration);

                if (entityConfiguration != null)
                {
                    var applyConfigurationMethod =
                        methodInfo.MakeGenericMethod(entityConfiguration.GenericTypeArguments[0]);
                    applyConfigurationMethod.Invoke(modelBuilder, new[] { Activator.CreateInstance(type) });
                }
            }

            //modelBuilder.Entity<Practice.Api.Database.Contact.Contact>().Property(x => x.name.first).HasColumnName("first");
            //modelBuilder.Entity<Practice.Api.Database.Contact.Contact>().Property(x => x.name.middle).HasColumnName("middle");
            //modelBuilder.Entity<Practice.Api.Database.Contact.Contact>().Property(x => x.name.last).HasColumnName("last");

            //modelBuilder.Entity<Practice.Api.Database.Contact.Contact>().Property(x => x.address.street).HasColumnName("street");
            //modelBuilder.Entity<Practice.Api.Database.Contact.Contact>().Property(x => x.address.city).HasColumnName("city");
            //modelBuilder.Entity<Practice.Api.Database.Contact.Contact>().Property(x => x.address.state).HasColumnName("state");
            //modelBuilder.Entity<Practice.Api.Database.Contact.Contact>().Property(x => x.address.zip).HasColumnName("zip");
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}