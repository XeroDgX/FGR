using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FGR.Models.Mapping
{
    public class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Nickname)
                .IsRequired()
                .HasMaxLength(50);
            // Table & Column Mappings
            this.ToTable("Players");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Nickname).HasColumnName("Nickname");
            this.Property(t => t.Status).HasColumnName("Status");
            
        }
    }
}
