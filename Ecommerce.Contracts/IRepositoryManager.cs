namespace Ecommerce.Contracts;

public interface IRepositoryManager
{
    IProductRepository ProductsRepository { get; }
    ICartRepository CartRepository { get; }
    IUserRepository UsersRepository { get; }
    IOrderRepository OrderRepository { get; }
    Task SaveAsync();
}
