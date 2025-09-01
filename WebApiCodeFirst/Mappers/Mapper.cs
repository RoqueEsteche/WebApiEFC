using AutoMapper;
using WebApiCodeFirst.Models;
using WebApiCodeFirst.Models.DTO;

namespace WebApiCodeFirst.Mappers
{
    public class Mapper : Profile
    {
        protected Mapper()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        }
    }
}
