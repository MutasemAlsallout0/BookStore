using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data
{
    public class BookStoreDbContext : IdentityDbContext<AppUser>
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserFavs>().HasKey(uf => new { uf.AppUserId, uf.BookId });

            AutoIncludeBookRelations(builder);
            SeedUser(builder);
            SeedAdmin(builder);
            OneToManyRelationships(builder);

            SeedRolesData(builder);

            builder.Entity<Address>().Navigation(a=>a.Zone).AutoInclude();

            base.OnModelCreating(builder);
        }

       

        public DbSet<Author> Authors { get; set; }
        public DbSet<Translator> Translators { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<UserFavs> UserFavs { get; set; }
        public DbSet<BookReviews> BookReviews { get; set; }

        public DbSet<Zone> Zones { get; set; }

        public DbSet<Sales> Sales { get; set; }

        public DbSet<Contactus> Contactus { get; set; }
        public DbSet<StaticPages> StaticPages { get; set; }

        public DbSet<BookSuggestion> BookSuggestions { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<OrderNotification> OrderNotifications { get; set; }






        private  void AutoIncludeBookRelations(ModelBuilder builder)
        {
            builder.Entity<Book>().Navigation(b => b.Author).AutoInclude();
            builder.Entity<Book>().Navigation(b => b.Category).AutoInclude();
            builder.Entity<Book>().Navigation(b => b.Translator).AutoInclude();
            builder.Entity<Book>().Navigation(b => b.Publisher).AutoInclude();
        }

        private  void OneToManyRelationships(ModelBuilder builder)
        {
            builder.Entity<Book>()
                        .HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey(b => b.AuthorId);


            builder.Entity<Book>()
            .HasOne(b => b.Category).WithMany(c => c.Books).HasForeignKey(b => b.CategoryId);
            builder.Entity<Book>()
            .HasOne(b => b.Translator).WithMany(t => t.Books).HasForeignKey(b => b.TranslatorId);

            builder.Entity<Book>()
           .HasOne(b => b.Publisher).WithMany(p => p.Books).HasForeignKey(b => b.PublisherId);

            builder.Entity<BookReviews>()
           .HasOne(br => br.Book).WithMany(b => b.BookReviews).HasForeignKey(br => br.BookId);
        }

        private void SeedUser(ModelBuilder modelBuilder)
        {
            var user = new AppUser
            {
                Id = "b5feebcf-f317-4117-81c5-f95c98e3999e",
                Email = "user@user.com",
                NormalizedEmail = "USER@USER.com",
                EmailConfirmed = true,
                FirstName = "Mohamed",
                LastName = "alQadeery",
                UserName = "MohamedAlQadeery",
                NormalizedUserName = "MOHAMEDALQADEERY"
            };

            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            user.PasswordHash = ph.HashPassword(user, "123123");
            modelBuilder.Entity<AppUser>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = "b5feebcf-f317-4117-81c5-f95c98e3999e",
                RoleId = "bd66ca1f-10a4-4087-a1be-41a256153d39"
            });

        }

        private  void SeedAdmin(ModelBuilder modelBuilder)
        {
            var admin = new AppUser
            {
                Id = "65574566-fef6-4857-903b-af23c2d795e9",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin",
                NormalizedUserName = "ADMIN"
            };

            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            admin.PasswordHash = ph.HashPassword(admin, "123123");
            modelBuilder.Entity<AppUser>().HasData(admin);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = "65574566-fef6-4857-903b-af23c2d795e9",
                RoleId = "80f3c65b-9f1c-4422-81b7-efaf1460cc8f"
            });
        }


        private  void SeedRolesData(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>()
               .HasData(new IdentityRole { Name = "admin", NormalizedName = "ADMIN" });
            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole { Name = "user", NormalizedName = "USER" });
        }

    }
}
