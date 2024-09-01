using AutoMapper;
using Ecommerce.Contracts;
using Ecommerce.Service.Contracts;

namespace Ecommerce.Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IProductService> productService;
    public ServiceManager(
        IRepositoryManager repoManager,
        IMapper mapper
    /* UserManager<User> userManager*/
    )
    {
        productService = new(() => new ProductService(repoManager, mapper));
    }


    public IProductService ProductService => productService.Value;


}
