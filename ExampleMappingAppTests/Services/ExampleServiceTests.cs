using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExampleMappingApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effort;
using Effort.Provider;

namespace ExampleMappingApp.Services.Tests
{
  [TestClass()]
  public class ExampleServiceTests
  {
    private ExampleMappingEntities context;


    [AssemblyInitialize]
    public static void AssemblyInit(TestContext context)
    {
      EffortProviderConfiguration.RegisterProvider();
    }

    [TestInitialize]
    public void SetUp()
    {
      //EffortProviderConfiguration.RegisterProvider();
      var conn = EntityConnectionFactory.CreateTransient("name=ExampleMappingEntities");
      //var conn = DbConnectionFactory.CreateTransient();
      context = new ExampleMappingEntities(conn);
    }


    [TestMethod()]
    public void AddFooBarObjectTest()
    {
      ExampleService svc = new ExampleService(context);

      int actual = svc.AddFooBarObject();
      int expected = 1;

      Assert.AreEqual(actual, expected);
    }
  }
}