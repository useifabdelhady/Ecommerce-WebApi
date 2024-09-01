using AutoMapper;
using Ecommerce.Contracts;
using Ecommerce.Service.Contracts;

namespace Ecommerce.Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IUserService> userService;
    private readonly Lazy<IProductService> productService;
    private readonly Lazy<ICartService> cartService;
    private readonly Lazy<IOrderService> orderService;
    public ServiceManager(
        IRepositoryManager repoManager,
        IMapper mapper
    /* UserManager<User> userManager*/
    )
    {
        userService = new(() => new UserService(repoManager, mapper));
        cartService = new(() => new CartService(repoManager, mapper));
        orderService = new(() => new OrderService(repoManager, mapper));
        productService = new(() => new ProductService(repoManager, mapper));
    }

    public ICartService CartService => cartService.Value;
    public IProductService ProductService => productService.Value;
    public IUserService UsersService => userService.Value;
    public IOrderService OrderService => orderService.Value;

}
