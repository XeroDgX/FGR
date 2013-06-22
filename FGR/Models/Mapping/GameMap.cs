using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FGR.Models.Mapping
{
    public class GameMap : EntityTypeConfiguration<Game>
    {
        public GameMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.GameTitle)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Games");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.GameTitle).HasColumnName("GameTitle");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
