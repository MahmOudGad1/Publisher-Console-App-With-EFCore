using Microsoft.EntityFrameworkCore;
using PublisherDomain;

namespace PublisherData
{
    public class PubContext:DbContext
    {
        public DbSet<Author> Authors {  get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PubDatatabase;Integrated Security=True;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //var authorlist = new Author[]
            //{
            //    new Author { Id = 1, Firstname = "mah", Lastname ="asccd"},
            //    new Author { Id = 5, Firstname = "mahsx", Lastname ="ascsd"},
            //    new Author { Id = 6, Firstname = "masddh", Lastname ="asc"},
            //    new Author { Id = 7, Firstname = "madsdh", Lastname ="asdsc"},
            //    new Author { Id = 8, Firstname = "madsdh", Lastname ="aswetsc"},
            //    new Author { Id = 9, Firstname = "mahdddd", Lastname ="sdsasc"},
            //    new Author { Id = 10, Firstname = "mahds", Lastname ="ascer"},
            //};

            //modelBuilder.Entity<Author>().HasData(authorlist);

            //modelBuilder.Entity<Author>().HasMany<Book>().WithOne();

            //here i ovverride  the convention of ef core and cjange the foriegn key name 
            //modelBuilder.Entity<Author>().
            //    HasMany<Book>(a => a.Books)
            //    .WithOne(b => b.Author).
            //    HasForeignKey(b => b.authorFK);

        }

    }
}