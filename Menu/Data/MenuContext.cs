using Microsoft.EntityFrameworkCore;
using Menu.Models;

namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId
            });
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredient>().HasOne(i => i.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredientId);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Hamburger", Price = 49.50, ImageUrl = "https://s7d1.scene7.com/is/image/mcdonalds/mcdonalds_hamburger:1-3-product-tile-desktop?wid=829&hei=515&dpr=off" }
                );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Bolle"},
                new Ingredient { Id = 2, Name = "Bøf"},
                new Ingredient { Id = 3, Name = "Dressing"}
                );
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 1},
                new DishIngredient { DishId = 1, IngredientId = 2},
                new DishIngredient { DishId = 1, IngredientId = 3}
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes{ get; set; }

        public DbSet<Ingredient> Ingredients { get; set;}

        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
