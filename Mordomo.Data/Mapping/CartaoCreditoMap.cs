using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class CartaoCreditoMap : EntityTypeConfiguration<CartaoCredito>
    {
        public CartaoCreditoMap()
        {
            // Primary Key
            this.HasKey(p =>p.Id);

            // Properties
            this.Property(p =>p.NumeroCarao)
                .IsRequired()
                .HasMaxLength(24);

            this.Property(p =>p.DigitoVerificador)
                .IsRequired()
                .HasMaxLength(3);
            
            this.Property(p =>p.MesExpricao)
                .IsRequired();

            this.Property(p =>p.AnoExpiracao)
                .IsRequired();

            this.Property(p =>p.DataModificacao)
                .IsRequired();
                        
            // Table & Column Mappings
            this.ToTable("CartaoCredito");
            this.Property(p =>p.Id).HasColumnName("Id");
            this.Property(p =>p.NumeroCarao).HasColumnName("NumeroCarao");
            this.Property(p =>p.DigitoVerificador).HasColumnName("DigitoVerificador");
            this.Property(p =>p.MesExpricao).HasColumnName("MesExpricao");
            this.Property(p =>p.AnoExpiracao).HasColumnName("AnoExpiracao");
            this.Property(p =>p.DataModificacao).HasColumnName("DataModificacao");
            
            //Relationships
            this.HasRequired(p => p.TipoCartaoCredito);               
        }
    }
}
