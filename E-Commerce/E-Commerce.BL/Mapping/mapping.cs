using AutoMapper;
using E_Commerce.BL.Dtos;
using E_Commerce.BL.Dtos.OrderDto;
using E_Commerce.DAL.models;
using E_Commerce.DAL.models.order;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Mapping
{
     public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductReadDto>()
                .ForPath(dest=>dest.CategoryName,opt=>opt.MapFrom(src=>src.Category.Name))
                .ForPath(dest=>dest.BrandName,opt=>opt.MapFrom(src=>src.Brand.Name)) 
                .ReverseMap();

            CreateMap<ProductAddOrUpdateDot , Product>().ReverseMap();


            CreateMap<Category, CategoryReadDto>().
           ForPath(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
            .ReverseMap();

            CreateMap<CategoryAddorUpdateDto, Category>().ReverseMap();


            CreateMap<Brand,BrandReadDto>()
            .ForPath(dest => dest.Products, opt => opt.MapFrom(src=>src.Products))
            .ReverseMap();

            CreateMap<BrandAddorUpdateDto, Brand>().ReverseMap();


            CreateMap<productedOrdered, ProductOrderedDto>().ReverseMap();


            CreateMap<Order, AddOrderDto>().ReverseMap();
            



        }
    }
}
