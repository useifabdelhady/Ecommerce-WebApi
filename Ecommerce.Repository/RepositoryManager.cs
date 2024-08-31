using Ecommerce.Contracts;

namespace Ecommerce.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;


    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;

    }


    public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    // todo: change to SaveChangesAsync()
}
