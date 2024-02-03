using AutoMapper;
using Portal.Core.Models;
using Portal.Infastration.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Mapper
{
    public class DomainProfile : Profile
    {

        public DomainProfile() {

            CreateMap<Department, DepartmentVM>().ReverseMap();


            CreateMap<EmployeeVm, Employee>().ReverseMap()
                .ForPath(dest => dest.id, source => source.MapFrom(a => a.id))
                .ForPath(dest => dest.Name, source => source.MapFrom(a => a.Name))
                .ForPath(dest => dest.Salary, source => source.MapFrom(a => a.Salary))
                .ForPath(dest => dest.Adrress, source => source.MapFrom(a => a.Adrress))
                .ForPath(dest => dest.Email, source => source.MapFrom(a => a.Email))
                .ForPath(dest => dest.Note, source => source.MapFrom(a => a.Note))
                .ForPath(dest => dest.IsActive, source => source.MapFrom(a => a.IsActive))
                .ForPath(dest => dest.IsDeleted, source => source.MapFrom(a => a.IsDeleted))
                .ForPath(dest => dest.DepartmentID, source => source.MapFrom(a => a.DepartmentID))
                .ForPath(dest => dest.CreateOn, source => source.MapFrom(a => a.CreateOn))
                .ForPath(dest => dest.DeleteOn, source => source.MapFrom(a => a.DeleteOn))
                .ForPath(dest => dest.UpdateOn, source => source.MapFrom(a => a.UpdateOn))
                .ForPath(dest => dest.IsDeleted, source => source.MapFrom(a => a.IsDeleted))
                .ForPath(dest => dest.IsUpdated, source => source.MapFrom(a => a.IsUpdated))
                .ForPath(dest => dest.IsDeleted, source => source.MapFrom(a => a.IsDeleted))
                 .ForPath(dest => dest.HireDate, source => source.MapFrom(a => a.HireDate))
                .ForPath(dest => dest.DepartmentName, source => source.MapFrom(a => a.department.Name))
                .ForPath(dest => dest.DepartmentCode, source => source.MapFrom(a => a.department.Code));





        }
    }

}
