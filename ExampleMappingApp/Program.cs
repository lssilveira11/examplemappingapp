using ExampleMappingApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMappingApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Press any key to insert an active Foo-Bar in database.");
      Console.ReadKey();

      using (ExampleMappingEntities db = new ExampleMappingEntities())
      {
        ExampleService svc = new ExampleService(db);

        int id = svc.AddFooBarObject();

        Console.WriteLine("An Foo-Bar object was added with ID " + id + ".");
        Console.ReadKey();
      }
    }
  }
}
