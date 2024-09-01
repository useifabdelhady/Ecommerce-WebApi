namespace Ecommerce.Service.Contracts
{
    public interface IServiceManager
    {
        ICartService CartService { get; }
        IProductService ProductService { get; }
    }
}
