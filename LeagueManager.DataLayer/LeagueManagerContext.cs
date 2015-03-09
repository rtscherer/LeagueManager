using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MySql.Data.Entity;
using System.Data.Common;
using LeagueManager.Domain;

namespace LeagueManager.DataLayer
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class LeagueManagerContext : DbContext
    {
        public DbSet<Team> Team { get; set; }
        public DbSet<Roster> Roster { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<League> League { get; set; }
        public DbSet<ContactPerson> ContactPerson { get; set; }
        public DbSet<Facility> Facility { get; set; }

        public LeagueManagerContext() : base() { }

        public LeagueManagerContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection) { }

        #region Commented
        //public DbSet<ContactPerson> ContactPerson { get; set; }
        //public DbSet<League> League { get; set; }
        //public DbSet<Facility> Facility { get; set; }
        //public DbSet<Location> Location { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<ContactPerson>().MapToStoredProcedures();

        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<League>().MapToStoredProcedures();

        //base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<Facility>().MapToStoredProcedures();

        //base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<Location>().MapToStoredProcedures();
        //} 
        #endregion
    }
}
