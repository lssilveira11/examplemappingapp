using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMappingApp.Services
{
  public class ExampleService : BaseService
  {
    public ExampleService(ExampleMappingEntities dbContext) : base(dbContext)
    {
    }

    public ExampleService(ObjectContext objContext) : base(objContext)
    {
    }

    public int AddFooBarObject()
    {
      EXAMPLE newObj = new EXAMPLE()
      {
        NAME = "Foo-Bar",
        ACTIVE = true
      };

      context.EXAMPLE.Add(newObj);

      context.SaveChanges();

      return newObj.ID;
    }
  }
}
