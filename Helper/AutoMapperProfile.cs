using AutoMapper;
using managementorder.Models;

namespace managementorder.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapping configuration for ClientViewModel to CustomerOrder
            CreateMap<ClientViewModel, CustomerOrder>()
                .ForMember(dest => dest.DT_RowId, opt => opt.MapFrom(src => "row_" + src.Id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.orderDate, opt => opt.Ignore()) // Set in nested mapping
                .ForMember(dest => dest.productName, opt => opt.Ignore())
                .ForMember(dest => dest.productPrice, opt => opt.Ignore())
                .ForMember(dest => dest.productStock, opt => opt.Ignore())
                .ForMember(dest => dest.productDesc, opt => opt.Ignore())
                .ForMember(dest => dest.orderNumber, opt => opt.Ignore());

            // Convert ClientViewModel list to CustomerOrder list directly
            CreateMap<List<ClientViewModel>, List<CustomerOrder>>().ConvertUsing((clients, context) =>
                clients.SelectMany(client => client.Orders.SelectMany(order =>
                    order.OrderProducts.Select(orderProduct => new CustomerOrder
                    {
                        DT_RowId = "row_" + (UniqueIdGenerator.GetUniqueId(client.Id, order.Id, orderProduct.Product.Id)).ToString(),
                        name = client.Name,
                        email = client.Email,
                        orderDate = order.OrderDate.ToString(),
                        productName = orderProduct.Product.Name,
                        productPrice = orderProduct.Product.Price.ToString(),
                        productStock = orderProduct.Product.Stock.ToString(),
                        productDesc = orderProduct.Product.Description,
                        orderNumber = order.Id.ToString(),
                    }))).ToList()
            );
        }
    }

}
