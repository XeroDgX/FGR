using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using FGR.Models.Mapping;

namespace FGR.Models
{
    public partial class dbFGRContext : DbContext
    {
        static dbFGRContext()
        {
            Database.SetInitializer<dbFGRContext>(null);
        }

        public dbFGRContext()
            : base("Name=dbFGRContext")
        {
        }

        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Ranking> Rankings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ChallengeMap());
            modelBuilder.Configurations.Add(new GameMap());
            modelBuilder.Configurations.Add(new PlayerMap());
            modelBuilder.Configurations.Add(new RankingMap());
        }
       

    }
}
