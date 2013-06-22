using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FGR.Models.Mapping
{
    public class RankingMap : EntityTypeConfiguration<Ranking>
    {
        public RankingMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Ranking");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.PlayerID).HasColumnName("PlayerID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.BattleScore).HasColumnName("BattleScore");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasRequired(t => t.Game)
                .WithMany(t => t.Rankings)
                .HasForeignKey(d => d.GameID);
            this.HasRequired(t => t.Player)
                .WithMany(t => t.Rankings)
                .HasForeignKey(d => d.PlayerID);

        }
    }
}
