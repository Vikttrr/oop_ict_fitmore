using FitmoRE.Application.Models.Entities;
using FitmoRE.Application.Repositories;
using FitmoRE.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FitmoRE.Infrastructure.Persistence.Repositories;

public class PaymentRepository
{
    
}

public class AccountRepository : BaseRepository<Account, AccountModel>, IAccountRepository
{
    public AccountRepository(ApplicationDbContext dbContext) : base(dbContext, dbContext.Accounts) { }

    public IAsyncEnumerable<Account> GetListByQuery(AccountQuery query)
    {
        var queryAdapter = new AccountQueryToEfOrmAdapter(query, DbContext);
        return queryAdapter.Adapt().AsAsyncEnumerable().Select(AccountMapper.ToEntity);
    }

    protected override Account MapToEntity(AccountModel model)
    {
        return AccountMapper.ToEntity(model);
    }

    protected override AccountModel MapToModel(Account entity)
    {
        return AccountMapper.ToModel(entity);
    }
}