using System.Data.Entity.Core.Objects;

namespace ExampleMappingApp.Services
{
  public class BaseService
  {
    protected ExampleMappingEntities context;

    public BaseService(ExampleMappingEntities dbContext)
    {
      this.context = dbContext;
    }

    public BaseService(ObjectContext objContext)
    {
      this.context = new ExampleMappingEntities(objContext);
    }

  }
}