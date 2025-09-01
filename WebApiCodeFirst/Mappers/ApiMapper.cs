using AutoMapper;
using WebApiCodeFirst.Models;
using WebApiCodeFirst.Models.DTO;

namespace WebApiCodeFirst.Mappers
{
    public class ApiMapper : Profile
    {
        public ApiMapper()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Categoria, CrearCategoriaDTO>().ReverseMap();
        }
    }
}