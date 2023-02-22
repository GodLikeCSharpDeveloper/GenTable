//using BlazorStoreServAppV5.Models.AuthModel;
//using GenericTableBlazorAppV5.Repositories;

//namespace BlazorStoreServAppV5.Repository.StoreLogic.DepInjLogic
//{
//    public class StoreRepositoryServiceFactory : IStoreRepositoryServiceFactory
//    {
//        private readonly IEnumerable<IStoreRepositoryServise> _services;

//        public StoreRepositoryServiceFactory(IEnumerable<IStoreRepositoryServise> storeRepositoryServises)
//        {
//            _services = storeRepositoryServises;
//        }

//        public IStoreRepositoryServise GetInstance(string token)
//        {
//            return token switch
//            {
//                "Product" => GetService(typeof(ProductRepository)),
//                "User" => GetService(typeof(UserRepository)),
//                "Order" => GetService(typeof(OrderRepository)),
//                "Description" => GetService(typeof(DescriptionRepository)),
//                _ => throw new InvalidOperationException()
//            };
//        }
//        public IStoreRepositoryServise GetService(Type type)
//        {
            
//            return _services.FirstOrDefault(x => x.GetType() == type)!;
//        }
//    }
//}
