using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {            
            // Primary Key
            this.HasKey(p => p.Id);

            // Properties
            this.Property(p =>p.DataModificacao)
                .IsRequired();
                        
            // Table & Column Mappings
            this.ToTable("Pessoa");
            this.Property(p =>p.Id).HasColumnName("Id");
            this.Property(p =>p.DataModificacao).HasColumnName("DataModificacao");

            // Relationships
            this.HasOptional(p => p.PessoaFisica);
            this.HasOptional(p => p.PessoaJuridica);
        }
    }
}
