using AutoMapper;
using Sela.Task.API.Models.Domain;
using Sela.Task.API.Models.DTO;

namespace Sela.Task.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TaskDetail, TaskDetailDto>().ReverseMap();
            CreateMap<AddTaskDetailRequestDto, TaskDetail>().ReverseMap();
            CreateMap<UpdateTaskDetailRequestDto, TaskDetail>().ReverseMap();
        }
    }
}
