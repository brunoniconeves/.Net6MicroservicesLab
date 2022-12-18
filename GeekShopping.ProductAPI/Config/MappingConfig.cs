using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
namespace GeekShopping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductVO, Product>();
                cfg.CreateMap<Product, ProductVO>();
            });
        }
    }
}
