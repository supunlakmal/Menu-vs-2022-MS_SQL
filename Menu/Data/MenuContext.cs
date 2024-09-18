using Microsoft.EntityFrameworkCore;
using Menu.Models;

namespace Menu.Data
{
    public class MenuContext: DbContext
    {
        public MenuContext( DbContextOptions<MenuContext> options  ) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DishIngredient>()
                .HasKey(di => new { di.DishId, di.IngredientId });

            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Dish).WithMany(d => d.DishIngredients).HasForeignKey(di => di.DishId);
            // need to add this line ingredient
            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Ingredient).WithMany(i => i.DishIngredients).HasForeignKey(di => di.IngredientId);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Pizza", Price = 10.99, ImageUrl = "https://www.google.com" },
                new Dish { Id = 2, Name = "Burger", Price = 5.99, ImageUrl = "https://www.google.com" },
                new Dish { Id = 3, Name = "Pasta", Price = 8.99, ImageUrl = "https://www.google.com" }
            );

            // add 3 ingredients
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Cheese" },
                new Ingredient { Id = 2, Name = "Tomato" },
                new Ingredient { Id = 3, Name = "Bread" }
            );

            // add 3 DishIngredients
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { Id = 1, DishId = 1, IngredientId = 1 },
                new DishIngredient { Id = 2, DishId = 1, IngredientId = 2 },
                new DishIngredient { Id = 3, DishId = 2, IngredientId = 3 }
            );


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
