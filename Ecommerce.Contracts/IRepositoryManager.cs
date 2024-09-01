namespace Ecommerce.Contracts;

public interface IRepositoryManager
{
    IProductRepository ProductsRepository { get; }
    ICartRepository CartRepository { get; }
    Task SaveAsync();
}
