using Dapper.Contrib.Extensions;

namespace Blog.Repositories;

public abstract class Repository<TModel> where TModel : class
{
    public IEnumerable<TModel> Get()
        => Database.Connection.GetAll<TModel>();

    public TModel Get(Guid id)
        => Database.Connection.Get<TModel>(id);

    public void Create(TModel model)
        => Database.Connection.Insert<TModel>(model);

    public void Update(TModel model)
        => Database.Connection.Update<TModel>(model);

    public void Delete(TModel model)
        => Database.Connection.Delete<TModel>(model);

    public void Delete(Guid id)
    {
        var model = Database.Connection.Get<TModel>(id);
        Database.Connection.Delete<TModel>(model);
    }
}
