using AutoMapper;
using InventoryManagement.Entities.Dtos;
using InventoryManagement.Entities.Models;

namespace InventoryManagement.WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, ProductViewModel>();

            CreateMap<SellerViewModel, Seller>();
            CreateMap<Seller, SellerViewModel>();

            CreateMap<SellingOrderViewModel, SellingOrder>();
            CreateMap<SellingOrder, SellingOrderViewModel>();

        }
    }
}
