using Ecommerce.Contracts;
using Ecommerce.Entities.Models;
using System.Linq.Expressions;

namespace Ecommerce.Repository;
public class OrderRepository : RepositoryBase<Cart>, IOrderRepository
{

    public OrderRepository(RepositoryContext context)
        : base(context)
    {

    }

    public void Create(Order entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Order entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Order> FindByCondition(Expression<Func<Order, bool>> condition)
    {
        throw new NotImplementedException();
    }

    public void Update(Order entity)
    {
        throw new NotImplementedException();
    }

    IQueryable<Order> IRepositoryBase<Order>.FindAll()
    {
        throw new NotImplementedException();
    }
}