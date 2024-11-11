﻿using AutoMapper;
using managementorder.Models;

namespace managementorder.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Map ClientViewModel to CustomerOrder
            CreateMap<ClientViewModel, CustomerOrder>()
                .ForMember(dest => dest.DT_RowId, opt => opt.MapFrom(src => "row_" + src.Id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders));  // This will map nested Orders

            // Map OrderViewModel to OrderViewModelToOrder
            CreateMap<OrderViewModel, OrderViewModelToOrder>()
                .ForMember(dest => dest.orderNumber, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.OrderProducts)); // Map OrderProducts to Products

            // Map OrderProductView to ProductViewModelToOrder using the nested Product property
            CreateMap<OrderProductView, ProductViewModelToOrder>()
                .ForMember(dest => dest.productName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.productPrice, opt => opt.MapFrom(src => src.Product.Price.ToString("F2")))
                .ForMember(dest => dest.productStock, opt => opt.MapFrom(src => src.Product.Stock.ToString()))
                .ForMember(dest => dest.productDesc, opt => opt.MapFrom(src => src.Product.Description));

            // Map ProductViewModelToClient directly to ProductViewModelToOrder (alternative if needed in other mappings)
            CreateMap<ProductViewModelToClient, ProductViewModelToOrder>()
                .ForMember(dest => dest.productName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.productPrice, opt => opt.MapFrom(src => src.Price.ToString("F2")))
                .ForMember(dest => dest.productStock, opt => opt.MapFrom(src => src.Stock.ToString()))
                .ForMember(dest => dest.productDesc, opt => opt.MapFrom(src => src.Description));
        }
    }
}
