using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {            
            // Primary Key
            this.HasKey(p => p.Id);

            // Properties
                        
            // Table & Column Mappings
            this.ToTable("Person");
            this.Property(p => p.Id).HasColumnName("Person_Id");
            

            // Relationships
            //this.HasOptional(p => p.LegalPerson)
            //    .WithRequired(p => p.Person);            
            
            //this.HasMany(p => p.Andresses)
            //    .WithRequired(p => p.Person)
            //    .WillCascadeOnDelete();
        }
    }
}
