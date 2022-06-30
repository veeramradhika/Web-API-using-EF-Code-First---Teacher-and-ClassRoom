using ApiEFDBProject.Entites;
using AutoMapper;
using WebApiProjectEFDb.APIModels;

namespace WebApiProjectEFDb.MappingConfigurations
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Teachers, TeachersAPIModel>().ReverseMap();
            CreateMap<ClassRoom, ClassRoomAPIModel>().ReverseMap();
        }
    }
}
