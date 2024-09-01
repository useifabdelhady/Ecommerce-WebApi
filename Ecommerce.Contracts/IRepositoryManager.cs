namespace Ecommerce.Contracts;

public interface IRepositoryManager
{
    IProductRepository ProductsRepository { get; }
    Task SaveAsync();
}
