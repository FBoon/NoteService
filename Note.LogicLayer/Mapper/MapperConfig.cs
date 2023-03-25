using AutoMapper;
using Note.DataLayer.Entities;

namespace Note.LogicLayer.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Employee, Models.Employee>().ReverseMap();
            CreateMap<Notation, Models.Notation>().ReverseMap();
            CreateMap<Employee, Models.Employee>();
            CreateMap<Notation, Models.Notation>();
        }
    }
}
