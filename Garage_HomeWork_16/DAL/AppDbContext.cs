
using Garage_HomeWork_16.Models;
using Microsoft.EntityFrameworkCore;

namespace Garage_HomeWork_16.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Card> Cards { get; set; }
        public DbSet<ContactIntro> ContactIntro { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryComponent> CategoryComponents { get; set; }
        public DbSet<ContactCard> ContactCards { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<RecentWork> RecentWorks { get; set; }
        public DbSet<PricingItem> PricingItems { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<FeaturedWorkComponent> FeaturedWorkComponent { get; set; }

        public DbSet<FeaturedWorkComponentPhoto> FeaturedWorkComponentPhotos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().HasData(
                new Card() { Id = 1, Title = "UI?UX Design", Text = "UI?UX Design text", FilePath = "/services-01.jpg" },
                new Card() { Id = 2, Title = "Social Media", Text = "Social Media text", FilePath = "/services-02.jpg" },
                new Card() { Id = 3, Title = "Marketing", Text = "Marketing text", FilePath = "/services-03.jpg" },
                new Card() { Id = 4, Title = "Graphic", Text = "Graphic  text", FilePath = "/services-04.jpg" },
                new Card() { Id = 5, Title = "Digital Marketing", Text = "Digital Marketing text", FilePath = "/services-05.jpg" },
                new Card() { Id = 6, Title = "Market Research", Text = "Market Researchtext", FilePath = "/services-06.jpg" }
            );
            modelBuilder.Entity<ContactIntro>().HasData(
                new ContactIntro()
                {
                    Id = 1,
                    Title = "Contact",
                    Description = "<h3 class=\"h4 regular-400\">Elit, sed do eiusmod tempor</h3>" +
                    "<p class=\"light-300\">Vector illustration is from <a rel=\"nofollow\" " + "href=\"https://storyset.com/\" " +
                    "target=\"_blank\">StorySet</a>.Incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse ultrices gravida.</p>",
                    FilePath = "/banner-img-01.svg"
                }
            );
            modelBuilder.Entity<Category>()
                .HasMany(c => c.CategoryComponents)
                .WithMany(cc => cc.Categories)
                .UsingEntity<CategoryCategoryComponents>();
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Title = "Business" },
                new Category { Id = 2, Title = "Marketing" },
                new Category { Id = 3, Title = "Social Media" },
                new Category { Id = 4, Title = "Graphic" }
            );
            modelBuilder.Entity<CategoryComponent>().HasData(
                new CategoryComponent()
                {
                    Id = 1,
                    Title = "Digital Marketing",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit,\r\nsed do eiusmod tempor incididunt ut labore et dolor.",
                    FilePath = "our-work-01.jpg"
                },
                new CategoryComponent()
                {
                    Id = 2,
                    Title = "Corporate Branding",
                    Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco\r\nlaboris nisi ut aliquip ex ea commodo consequat.",
                    FilePath = "our-work-02.jpg"
                },
                new CategoryComponent()
                {
                    Id = 3,
                    Title = "Leading Digital Solution",
                    Description = "Duis aute irure dolor in reprehenderit in voluptate velit\r\nesse cillum dolore eu fugiatdolore eu fugiat nulla pariatur.",
                    FilePath = "our-work-03.jpg"
                },
                new CategoryComponent()
                {
                    Id = 4,
                    Title = "Smart Applications",
                    Description = "Excepteur sint occaecat cupidatat non proident, sunt in\r\nculpa qui officia deserunt mollit anim id est laborum.",
                    FilePath = "our-work-04.jpg"
                },
                new CategoryComponent()
                {
                    Id = 5,
                    Title = "Corporate Stationary",
                    Description = "Excepteur sint occaecat cupidatat non proident,\r\nsunt in culpa qui officia deserunt mollit anim id est laborum.",
                    FilePath = "our-work-05.jpg"
                },
                new CategoryComponent()
                {
                    Id = 6,
                    Title = "8 Financial Tips",
                    Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco\r\nlaboris nisi ut aliquip ex ea commodo consequat.",
                    FilePath = "our-work-06.jpg"
                }
            );
            modelBuilder.Entity<CategoryCategoryComponents>().HasData(
                new CategoryCategoryComponents() { Id = 1, CategoryComponentId = 1, CategoryId = 3 },
                new CategoryCategoryComponents() { Id = 2, CategoryComponentId = 1, CategoryId = 2 },
                new CategoryCategoryComponents() { Id = 3, CategoryComponentId = 1, CategoryId = 1 },
                new CategoryCategoryComponents() { Id = 4, CategoryComponentId = 2, CategoryId = 4 },
                new CategoryCategoryComponents() { Id = 5, CategoryComponentId = 2, CategoryId = 3 },
                new CategoryCategoryComponents() { Id = 6, CategoryComponentId = 3, CategoryId = 2 },
                new CategoryCategoryComponents() { Id = 7, CategoryComponentId = 3, CategoryId = 4 },
                new CategoryCategoryComponents() { Id = 8, CategoryComponentId = 3, CategoryId = 1 },
                new CategoryCategoryComponents() { Id = 9, CategoryComponentId = 4, CategoryId = 3 },
                new CategoryCategoryComponents() { Id = 10, CategoryComponentId = 4, CategoryId = 1 },
                new CategoryCategoryComponents() { Id = 11, CategoryComponentId = 5, CategoryId = 2 },
                new CategoryCategoryComponents() { Id = 12, CategoryComponentId = 6, CategoryId = 2 },
                new CategoryCategoryComponents() { Id = 13, CategoryComponentId = 6, CategoryId = 4 }
            );
            modelBuilder.Entity<Contact>().HasData(
                new Contact()
                {
                    Id = 1,
                    Title = "Create success campaign with us!",
                    Text = "Elit, sed do eiusmod tempor",
                    Description = "Incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse ultrices\r\n" +
                    "gravida. Risus commodo viverra maecenas accumsan lacus vel facilisis. Laboris\r\n" +
                    "nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit\r\n" +
                    "in voluptate."
                }
            );
            modelBuilder.Entity<ContactCard>().HasData(
                new ContactCard()
                {
                    Id = 1,
                    Title = "Media Contact",
                    Fullname = "Mr. John Doe",
                    PhoneNumber = "010-020-0340",
                    IconClassName = "news",
                    ContactId = 1
                },
                new ContactCard()
                {
                    Id = 2,
                    Title = "Technical Contact",
                    Fullname = "Mr. John Stiles",
                    PhoneNumber = "010-020-0340",
                    IconClassName = "laptop",
                    ContactId = 1
                },
                new ContactCard()
                {
                    Id = 3,
                    Title = "Billing Contact",
                    Fullname = "Mr. Richard Miles",
                    PhoneNumber = "010-020-0340",
                    IconClassName = "money",
                    ContactId = 1
                }
            );
            modelBuilder.Entity<RecentWork>().HasData(
                new RecentWork()
                {
                    Id = 1,
                    Title = "Social Media",
                    Text = "Ullamco laboris nisi ut aliquip ex",
                    ImagePath = "/assets/img/recent-work-01.jpg"
                },
                new RecentWork()
                {
                    Id = 2,
                    Title = "Web Marketing",
                    Text = "Psum officia anim id est laborum.",
                    ImagePath = "/assets/img/recent-work-02.jpg"
                },
                new RecentWork()
                {
                    Id = 3,
                    Title = "R & D",
                    Text = "Sum dolor sit consencutur",
                    ImagePath = "/assets/img/recent-work-03.jpg"
                },
                new RecentWork()
                {
                    Id = 4,
                    Title = "Public Relation",
                    Text = "Lorem ipsum dolor sit amet",
                    ImagePath = "/assets/img/recent-work-04.jpg"
                },
                new RecentWork()
                {
                    Id = 5,
                    Title = "Branding",
                    Text = "Put enim ad minim veniam",
                    ImagePath = "/assets/img/recent-work-05.jpg"
                },
                new RecentWork()
                {
                    Id = 6,
                    Title = "Creative Design",
                    Text = "Mollit anim id est laborum.",
                    ImagePath = "/assets/img/recent-work-06.jpg"
                });
            modelBuilder.Entity<PricingItem>().HasData(
            new PricingItem()
            {
                Id = 1,
                Title = "Free",
                UserCount = "5 Users",
                SpaceSize = 2,
                Description = "Community Forums",
                Cost = 0
            },
            new PricingItem()
            {
                Id = 2,
                Title = "Standart",
                UserCount = "25  to 99 Users",
                SpaceSize = 10,
                Description = "Live Chat",
                Cost = 120
            },
            new PricingItem()
            {
                Id = 3,
                Title = "Enterprise",
                UserCount = "100 Users or more",
                SpaceSize = 80,
                Description = "Customizations",
                Cost = 840
            },
            new PricingItem()
            {
                Id = 4,
                Title = "Title4",
                UserCount = "15 Users",
                SpaceSize = 15,
                Description = "Description4",
                Cost = 150
            },
            new PricingItem()
            {
                Id = 5,
                Title = "Title5",
                UserCount = "50 Users",
                SpaceSize = 25,
                Description = "Description5",
                Cost = 100
            },
            new PricingItem()
            {
                Id = 6,
                Title = "Title6",
                UserCount = "65 Users",
                SpaceSize = 30,
                Description = "Description6",
                Cost = 60
            });
            modelBuilder.Entity<TeamMember>().HasData(
            new TeamMember()
            {
                Id = 1,
                Name = "John",
                Surname = "Doe",
                Position = "Business Development",
                PhotoName = "team-01.jpg",
            },
            new TeamMember()
            {
                Id = 2,
                Name = "Jane",
                Surname = "Doe",
                Position = "Media Development",
                PhotoName = "team-02.jpg",
            },
            new TeamMember()
            {
                Id = 3,
                Name = "Sam",
                Surname = "",
                Position = "Developer",
                PhotoName = "team-03.jpg",
            });
            modelBuilder.Entity<FeaturedWorkComponent>().HasData(
                new FeaturedWorkComponent()
                {
                    Id = 1,
                    Title = "Featured Work",
                    Description = "<h2><strong>Transform with us</strong></h2><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse ultrices gravida. Risus commodo viverra maecenas accumsan lacus vel facilisis.</p><p>Consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse ultrices gravida. Risus commodo viverra maecenas. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p>"
                });
            modelBuilder.Entity<FeaturedWorkComponentPhoto>().HasData(
                new FeaturedWorkComponentPhoto()
                {
                    Id = 1,
                    Order = 1,
                    FeaturedWorkComponentId = 1,
                    PhotoPath = "feature-work-1.jpg"
                },
                new FeaturedWorkComponentPhoto()
                {
                    Id = 2,
                    Order = 2,
                    FeaturedWorkComponentId = 1,
                    PhotoPath = "feature-work-2.jpg"
                },
                new FeaturedWorkComponentPhoto()
                {
                    Id = 3,
                    Order = 3,
                    FeaturedWorkComponentId = 1,
                    PhotoPath = "feature-work-3.jpg"
                },
                new FeaturedWorkComponentPhoto()
                {
                    Id = 4,
                    Order = 4,
                    FeaturedWorkComponentId = 1,
                    PhotoPath = "feature-work-4.jpg"
                });

        }
    }
}
