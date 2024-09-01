using AutoMapper;
using Ecommerce.Contracts;
using Ecommerce.Service.Contracts;

namespace Ecommerce.Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IProductService> productService;
    private readonly Lazy<ICartService> cartService;
    public ServiceManager(
        IRepositoryManager repoManager,
        IMapper mapper
    /* UserManager<User> userManager*/
    )
    {

        cartService = new(() => new CartService(repoManager, mapper));
        productService = new(() => new ProductService(repoManager, mapper));
    }

    public ICartService CartService => cartService.Value;
    public IProductService ProductService => productService.Value;


}
