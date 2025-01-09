using AutoMapper;
using Books.Core.DTOs;
using Books.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book,BookDTO>().ReverseMap();
            CreateMap<BookBuyer,BookBuyerDTO>().ReverseMap();
            CreateMap<BookSeller,BookSellerDTO>().ReverseMap();
        }
    }
}
