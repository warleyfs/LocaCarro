using LocaCarro.Domain.Entities;
using LocaCarro.Infraestructure.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCarro.Infraestructure.Data.Context
{
    public class LocaCarroDBContext : DbContext, ILocaCarroDBContext
    {
        public LocaCarroDBContext() : base("LocaCarroDBContext")
        {
            Database.SetInitializer<LocaCarroDBContext>(new CreateDatabaseIfNotExists<LocaCarroDBContext>());
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<Carro> Carro { get; set; }
        public DbSet<TipoCarro> TipoCarro { get; set; }
        public DbSet<Loja> Loja { get; set; }
        public DbSet<Tarifa> Tarifa { get; set; }
        public DbSet<Cliente> Cliente { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == "Id")
                .Configure(p => p.IsKey());
                        
            modelBuilder.Configurations.Add(new CarroConfig());
            modelBuilder.Configurations.Add(new TipoCarroConfig());
            modelBuilder.Configurations.Add(new TarifaConfig());
            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new LojaConfig());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        {
                            entry.Property("Id").CurrentValue = Guid.NewGuid();
                            entry.Property("CriadoEm").CurrentValue = DateTime.Now;
                            break;
                        }
                    case EntityState.Deleted:
                        {
                            break;
                        }
                    case EntityState.Modified:
                        {
                            entry.Property("CriadoEm").IsModified = false;
                            entry.Property("AlteradoEm").CurrentValue = DateTime.Now;
                            break;
                        }
                }
            }

            return base.SaveChanges();
        }
    }
}
