using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2pod2.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }
        public MainDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<File> File { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Team> Team { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<File>(m =>
            {
                m.HasKey(e => new { e.FileID, e.TeamID });
                m.Property(e => e.FileName).IsRequired().HasMaxLength(100);
                m.Property(e => e.FileExtension).IsRequired().HasMaxLength(4);
                m.Property(e => e.FileSize).IsRequired();

                m.HasOne(e => e.Team)
                .WithMany(e => e.File)
                .HasForeignKey(e => e.TeamID);
                m.HasData(
                    new File { FileID = 1, TeamID = 2, FileName = "Jan", FileExtension = "abcd", FileSize = 4 },
                    new File { FileID = 2, TeamID = 1, FileName = "Adam", FileExtension = "dbcd", FileSize = 4 });
            });

            modelbuilder.Entity<Member>(mt =>
            {
                mt.HasKey(e => e.MemberID);
                mt.Property(e => e.MemberName).IsRequired().HasMaxLength(20);
                mt.Property(e => e.MemberSurname).IsRequired().HasMaxLength(50);
                mt.Property(e => e.MemberNickName).HasMaxLength(50);

                mt.HasOne(e => e.Organization)
                .WithMany(e => e.Member)
                .HasForeignKey(e => e.OrganizationID);

                mt.HasData(
                  new Member { MemberID = 1, MemberName = "cos1 ", MemberSurname = "ON", MemberNickName = "Kos", OrganizationID = 2 },
                    new Member { MemberID = 2, MemberName = "cos2", MemberSurname = "DP", MemberNickName = "Trzos", OrganizationID = 1 });
            });

            modelbuilder.Entity<Membership>(t =>
            {
                t.HasKey(e => new { e.MemberID, e.TeamID });
                t.Property(e => e.MembershipDate).IsRequired();

                t.HasOne(e => e.Member)
                 .WithMany(e => e.Membership)
                 .HasForeignKey(e => e.MemberID);
                t.HasOne(e => e.Team)
                 .WithMany(e => e.Membership)
                 .HasForeignKey(e => e.TeamID);
                t.HasData(
                    new Membership { MemberID = 1, TeamID = 2, MembershipDate = DateTime.Now },
                    new Membership { MemberID = 2, TeamID = 1, MembershipDate = DateTime.Now });
            });

            modelbuilder.Entity<Organization>(a =>
            {
                a.HasKey(e => e.OrganizationID);
                a.Property(e => e.OrganizationName).IsRequired().HasMaxLength(100);
                a.Property(e => e.OrganizationDomain).IsRequired().HasMaxLength(50);


                a.HasData(
                    new Organization { OrganizationID = 1, OrganizationName = "123", OrganizationDomain = "nwm" },
                    new Organization { OrganizationID = 2, OrganizationName = "321", OrganizationDomain = "pomocy" });
            });


            modelbuilder.Entity<Team>(ml =>
            {
                ml.HasKey(e => e.TeamID);
                ml.Property(e => e.TeamName).IsRequired().HasMaxLength(30);
                ml.Property(e => e.TeamDescription).HasMaxLength(500);

                ml.HasOne(e => e.Organization)
              .WithMany(e => e.Team)
              .HasForeignKey(e => e.OrganizationID);
                ml.HasData(
                    new Team { TeamID = 1, TeamName = "KOWALELOSU", TeamDescription = "cos se tam robia" },
                    new Team { TeamID = 2, TeamName = "MAESTRO", TeamDescription = "praca praca praca" }); ;
            });
        }
    }
}
