using Ecommerce.Contracts;
using Ecommerce.Repository.ModelsRepository;

namespace Ecommerce.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<ICartRepository> cartRepository;
    private readonly Lazy<IUserRepository> userRepository;
    private readonly Lazy<IProductRepository> productRepository;


    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        userRepository = new(() => new UserRepository(repositoryContext));
        cartRepository = new(() => new CartRepository(repositoryContext));

        productRepository = new(() => new ProductRepository(repositoryContext));


    }
    public ICartRepository CartRepository => cartRepository.Value;
    public IUserRepository UsersRepository => userRepository.Value;
    public IProductRepository ProductsRepository => productRepository.Value;

    public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    // todo: change to SaveChangesAsync()
}
