# Example Mapping App

This app was created with intend to make an example of mapping configuration with Oracle Provider and Entity Framework.

The EXAMPLE entity has an Boolean property called ACTIVE, but at the database, the column is NUMBER(1,0).

Adding the following section in App.config, we can map all the NUMBER(1,0) fields to Boolean (true=1, false=0):

```xml
  <oracle.dataaccess.client>
    <settings>
      <add name="bool" value="edmmapping number(1,0)" />
    </settings>
  </oracle.dataaccess.client>
```

# The Effort Problem

The solution has an test project, with Effort, but when running the tests, we get the following error:

```
Test Name:	AddFooBarObjectTest
Test FullName:	ExampleMappingApp.Services.Tests.ExampleServiceTests.AddFooBarObjectTest
Test Source:	C:\Users\lucas\source\repos\ExampleMappingApp\ExampleMappingAppTests\Services\ExampleServiceTests.cs : line 36
Test Outcome:	Failed
Test Duration:	0:00:01,4662719

Result StackTrace:	
em System.Data.Entity.Core.Mapping.StorageMappingItemCollection.Init(EdmItemCollection edmCollection, StoreItemCollection storeCollection, IEnumerable`1 xmlReaders, IList`1 filePaths, Boolean throwOnError)
   em System.Data.Entity.Core.Mapping.StorageMappingItemCollection..ctor(EdmItemCollection edmCollection, StoreItemCollection storeCollection, IEnumerable`1 xmlReaders)
   em Effort.Internal.Common.MetadataWorkspaceHelper.CreateMetadataWorkspace(List`1 csdl, List`1 ssdl, List`1 msl)
   em Effort.Internal.Common.MetadataWorkspaceHelper.Rewrite(String metadata, String providerInvariantName, String providerManifestToken)
   em Effort.EntityConnectionFactory.<>c.<GetEffortCompatibleMetadataWorkspace>b__10_0(String metadata)
   em Effort.Internal.Caching.MetadataWorkspaceStore.<>c__DisplayClass2_0.<GetMetadataWorkspace>b__0()
   em System.Lazy`1.CreateValue()
   em System.Lazy`1.LazyInitValue()
   em System.Lazy`1.get_Value()
   em Effort.Internal.Caching.ConcurrentCache`2.Get(TKey key, Func`1 factory)
   em Effort.Internal.Caching.MetadataWorkspaceStore.GetMetadataWorkspace(String metadata, Func`2 workspaceFactoryMethod)
   em Effort.EntityConnectionFactory.GetEffortCompatibleMetadataWorkspace(String& entityConnectionString)
   em Effort.EntityConnectionFactory.CreateTransient(String entityConnectionString, IDataLoader dataLoader)
   em Effort.EntityConnectionFactory.CreateTransient(String entityConnectionString)
   em ExampleMappingApp.Services.Tests.ExampleServiceTests.SetUp() na C:\Users\lucas\source\repos\ExampleMappingApp\ExampleMappingAppTests\Services\ExampleServiceTests.cs:linha 29
Result Message:	
Initialization method ExampleMappingApp.Services.Tests.ExampleServiceTests.SetUp threw exception. System.Data.Entity.Core.MappingException: Schema specified is not valid. Errors: 
(0,0) : error 2019: Member Mapping specified is not valid. The type 'Edm.Boolean[Nullable=False,DefaultValue=]' of member 'ACTIVE' in type 'ExampleMappingModel.EXAMPLE' is not compatible with 'Effort.decimal[Nullable=False,DefaultValue=,Precision=1,Scale=0]' of member 'ACTIVE' in type 'ExampleMappingModel.Store.EXAMPLE'..
```

# How to run this app

- First, create an schema called EXAMPLEMAPPING (password also EXAMPLEMAPPING) at an existing Oracle database.
- Run the "Script_Metadata_EXAMPLEMAPPING_ORA.sql" to create the EXAMPLE table.
- Then, configure the "SampleDataSource" at <oracle.manageddataaccess.client> section of App.config, fot both projects ExampleMappingApp and ExampleMappingAppTest.
- Build the project and run the tests