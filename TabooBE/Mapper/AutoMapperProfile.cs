using AutoMapper;
using TabooBE.Models.DBModels;
using TabooBE.Models.DTOs.Requests;

namespace TabooBE.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<WordDTO, PendingWordDBModel>().ReverseMap();
            CreateMap<WordDTO, WordDBModel>().ReverseMap();
            CreateMap<PendingWordDBModel, WordDBModel>().ReverseMap();
        }
    }
}
