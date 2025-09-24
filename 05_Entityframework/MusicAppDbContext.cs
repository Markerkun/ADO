using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _05_Entityframework.Entities;


namespace _05_Entityframework
{
    internal class MusicAppDbContext : DbContext
    {
       
            //C       R    U       D 
            //Create Read Update Delede
            public MusicAppDbContext()
            {
            this.Database.EnsureCreated();
        }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog = MusicApp;
                                        Integrated Security=True;
                                        Connect Timeout=5;
                                        Encrypt=False;Trust Server Certificate=False;
                                        Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            //Start initialization
            modelBuilder.Entity<Country>().HasData(new Country[]
                {
                new Country()
                {
                    Id = 1,
                    Name = "Armenia"
                },
                 new Country()
                {
                     Id = 2,
                    Name = "USA"
                }
            });

            modelBuilder.Entity<Artist>().HasData(new Artist[]
              {
                new Artist()
                {
                    Id = 1,
                    Name = "FamousMe",
                    Surname = "TheBest",
                    CountryId = 1
                },
                 new Artist()
                {
                     Id = 2,
                     Name = "John Doe",
                        Surname = "Smith",
                        CountryId = 2
                },
                    new Artist()
                {
                        Id = 3,
                        Name = "Jane",
                            Surname = "Doe",
                            CountryId = 2
                }

              });
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre()
                {
                    Id = 1,
                    Name = "Pop"
                },
                 new Genre()
                {
                     Id = 2,
                    Name = "Rock"
                }
            });
            modelBuilder.Entity<Album>().HasData(new Album[]
                {
                new Album()
                {
                    Id = 1,
                    Name = "MyAlbum",
                    ArtistId = 1,
                    GenreId = 1

                },
                 new Album()
                {
                     Id = 2,
                    Name = "UnknownAlbum",
                    ArtistId = 2,
                    GenreId = 2
                }

                });
            modelBuilder.Entity<Playlist>().HasData(new Playlist[]
                {
                new Playlist()
                {
                    Id = 1,
                    Name = "MyPlaylist"
                },
                 new Playlist()
                {
                     Id = 2,
                    Name = "UnknownPlaylist"
                }
            });
            modelBuilder.Entity<Category>().HasData(new Category[]
                {
                new Category()
                {
                    Id = 1,
                    Name = "MyCategory"
                },
                 new Category()
                {
                     Id = 2,
                    Name = "UnknownCategory"
                }
            });
            modelBuilder.Entity<Track>().HasData(new Track[]
                {
                new Track()
                {
                    Id = 1,
                    Name = "MyTrack",
                    Duration = 3.5,
                    AlbumId = 1,
                    PlaylistId = 1, CategoryId = 1
                },
                 new Track()
                {
                     Id = 2,
                    Name = "UnknownTrack",
                    Duration = 4.0,
                    AlbumId = 2,
                    PlaylistId = 2, CategoryId = 1
                }
            });





        }

            /// Collection 
            ///List<Clients>
            ///Flights
            ///Airplanes
            public DbSet<Artist> Artists { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Playlist> Playlists { get; set; }



    }
}
