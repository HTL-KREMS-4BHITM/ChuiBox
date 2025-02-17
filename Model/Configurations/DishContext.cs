using Microsoft.EntityFrameworkCore;
using Model.Entites;

namespace Model.Configurations;


public class DishContext : DbContext
{
    public DishContext(DbContextOptions<DishContext> options) : base(options)
    {
        
    }

    public DbSet<Dish> Dishes { get; set; }
}