using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Models
{
    public interface IMusicDbContext
    {
        public DbSet<Track> Doctors { get; set; }

    }
    public class MainDbContext : DbContext
    {
        public MainDbContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Track> Track { get; set; }
        public DbSet<Musician> Musician { get; set; }
        public DbSet<MusicianTrack> MusicianTrack { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<MusicLabel> MusicLabel { get; set; }


        protected MainDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Track>(t =>
            {
                t.HasKey(e => e.IdTrack);
                t.Property(e => e.TrackName);
                t.Property(e => e.Duration);

                t.HasOne(e => e.Album).WithMany(e => e.Track).HasForeignKey(e => e.IdMusicAlbum);

                t.HasData(
                    new Track {IdTrack=1,TrackName="GluchaNoc",Duration=290 },
                    new Track { IdTrack = 2, TrackName = "BielyjeNosy", Duration = 390 });
            });
            modelBuilder.Entity<Musician>(m =>
            {
                m.HasKey(e => e.IdMusician);
                m.Property(e => e.FirstName);
                m.Property(e => e.LastName);
                m.Property(e => e.Nickname);

                m.HasData(
                    new Musician { IdMusician = 1, FirstName = "Jacek", LastName = "Graniewski", Nickname = "Tede" },
                    new Musician { IdMusician = 2, FirstName = "Ryszard", LastName = "Andrzejewski", Nickname = "Peja" });
            });
            modelBuilder.Entity<MusicianTrack>(m =>
            {
                m.HasKey(e => e.IdTrack);
                m.HasKey(e => e.IdMusician);

                m.HasOne(e => e.Musician).WithMany(e => e.MusicanTrack).HasForeignKey(e => e.IdMusician);
                m.HasOne(e => e.Track).WithMany(e => e.MusicanTrack).HasForeignKey(e => e.IdTrack);


                m.HasData(
                    new MusicianTrack { IdTrack = 1, IdMusician = 1 },
                    new MusicianTrack { IdTrack = 2, IdMusician = 2 });
            });
            modelBuilder.Entity<Album>(a =>
            {
                a.HasKey(e => e.IdAlbum);
                a.HasKey(e => e.IdMusicLabel);
                a.Property(e => e.AlbumName);
                a.Property(e => e.PublishDate);

                a.HasOne(e => e.MusicLabel).WithMany(e => e.Album).HasForeignKey(e => e.IdMusicLabel);

                a.HasData(
                    new Album { IdAlbum=1, IdMusicLabel=1, AlbumName="bruh", PublishDate=DateTime.Parse("2000-01-01") },
                    new Album { IdAlbum = 2, IdMusicLabel = 2, AlbumName = "bruh2", PublishDate = DateTime.Parse("2000-01-01") }
                    );

            });
            modelBuilder.Entity<MusicLabel>(m =>
            {
                m.HasKey(e => e.IdMusicLabel);
                m.Property(e => e.Name);


                m.HasData(
                    new MusicLabel { IdMusicLabel = 1, Name = "PROSTO"},
                    new MusicLabel { IdMusicLabel = 2, Name = "KRZYWO" });
            });


        }
    }
}
