using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FGR.Models.Mapping
{
    public class ChallengeMap : EntityTypeConfiguration<Challenge>
    {
        public ChallengeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Challenges");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.ChallengerPlayerID).HasColumnName("ChallengerPlayerID");
            this.Property(t => t.RivalPlayerID).HasColumnName("RivalPlayerID");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            this.HasRequired(t => t.Game)
                .WithMany(t => t.Challenges)
                .HasForeignKey(d => d.GameID);
            this.HasRequired(t => t.Ranking)
                .WithMany(t => t.Challenges)
                .HasForeignKey(d => d.ChallengerPlayerID);
            this.HasRequired(t => t.Ranking1)
                .WithMany(t => t.Challenges1)
                .HasForeignKey(d => d.RivalPlayerID);

        }
    }
}
