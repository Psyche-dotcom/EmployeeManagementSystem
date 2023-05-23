using AutoMapper;
using EmployeeManagement.Model;
using EmployeeManagement.Model.ModelDTO;

namespace EmploymentManagement.API.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() { 
        CreateMap<EmployeeDto, Employee>().ReverseMap();      
        }
    }
}
