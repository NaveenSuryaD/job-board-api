using AutoMapper;
using JobBoardApi.Models;
using JobBoardApi.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Jobpost, JobPostDto>().ReverseMap();
        CreateMap<Jobpost, JobPostResponseDto>();
    }
}