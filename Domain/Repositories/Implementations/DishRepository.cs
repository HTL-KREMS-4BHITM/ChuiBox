using Model.Configurations;
using Model.Entites;

namespace Domain.Repositories.Implementations;

public class DishRepository : ARepository<Dish>
{
    public DishRepository(DishContext context) : base(context)
    {
    }
}