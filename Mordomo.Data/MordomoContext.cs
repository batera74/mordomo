using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Mordomo.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.Entity.Validation;

namespace Mordomo.Data
{
    public class MordomoContext : DbContext
    {
        public DbSet<CreditCard> CreditCard { get; set; }
        public DbSet<CreditCardType> CreditCardType { get; set; }
        public DbSet<AndressType> AndressType { get; set; }
        public DbSet<Andress> Andress { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<PhysicalPerson> PhysicalPerson { get; set; }
        public DbSet<LegalPerson> LegalPerson { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<AccountMovement> AccountMovement { get; set; }
        public DbSet<Credit> Credit { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<ServiceOrderItem> ItemServiceOrder { get; set; }
        public DbSet<ServiceOrder> ServiceOrder { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }        



        public MordomoContext()
            : base("Mordomo2")
        {
            //Database.SetInitializer<MordomoContext>(new CreateMySqlDatabaseIfNotExists<DbContext>());          
            Database.SetInitializer<MordomoContext>(new CreateDatabaseIfNotExists<DbContext>());          
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new Mapping.CreditCardMap());
            modelBuilder.Configurations.Add(new Mapping.CreditCardTypeMap());
            modelBuilder.Configurations.Add(new Mapping.AndressMap());
            modelBuilder.Configurations.Add(new Mapping.AndressTypeMap());
            modelBuilder.Configurations.Add(new Mapping.CityMap());
            modelBuilder.Configurations.Add(new Mapping.StateMap());
            modelBuilder.Configurations.Add(new Mapping.PhysicalPersonMap());
            modelBuilder.Configurations.Add(new Mapping.LegalPersonMap());            
            modelBuilder.Configurations.Add(new Mapping.ClientMap());
            modelBuilder.Configurations.Add(new Mapping.PlanMap());
            modelBuilder.Configurations.Add(new Mapping.AccountMovementMap());
            modelBuilder.Configurations.Add(new Mapping.CreditMap());
            modelBuilder.Configurations.Add(new Mapping.AccountMap());
            modelBuilder.Configurations.Add(new Mapping.StatusMap());
            modelBuilder.Configurations.Add(new Mapping.ServiceOrderItemMap());
            modelBuilder.Configurations.Add(new Mapping.ServiceOrderMap());
            modelBuilder.Configurations.Add(new Mapping.ProviderMap());
            modelBuilder.Configurations.Add(new Mapping.MenuMap());
            modelBuilder.Configurations.Add(new Mapping.MenuItemMap()); 
        }

        public override int SaveChanges()
        {
            // Detecta as alterações efetuadas sobre as entidades
            this.ChangeTracker.DetectChanges();

            // Identifica as instâncias de 'Document' existentes 
            // dentro do ChangeTracker
            var entities = ChangeTracker.Entries<EntityBase>();

            if (entities != null)
            {
                // Varre os 'Documents' existentes no ChangeTracker
                foreach (DbEntityEntry<EntityBase> item in entities)
                {
                    // Verifica o State do item
                    switch (item.State)
                    {
                        case EntityState.Added:
                            item.Entity.LastUpdate = item.Entity.CreationTime = DateTime.Now;
                            break;
                        case EntityState.Modified:
                            item.Entity.LastUpdate = DateTime.Now;
                            break;
                    }
                }
            }

            try
            {
                // Realiza a gravação dos itens na base de dados
                return base.SaveChanges();
            }
            catch(DbEntityValidationException ex)
            {
                var errors = ex.EntityValidationErrors;

                foreach (DbEntityValidationResult item in errors)
                {
                    foreach (DbValidationError itemError in item.ValidationErrors)
                    {
                        Console.WriteLine(itemError.PropertyName + " " + itemError.ErrorMessage);
                    }
                }

                Console.Read();
                throw ex;
            }
        }
    }
}
