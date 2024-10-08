using Application.Interfaces;
using Infrastructure.Interfaces;
using Application.DTO.DepartmentAndRoles;
using AutoMapper;

namespace Application.Services
{
    public class DepartmentAndRolesServices : IDepartmentAndRolesServices
    {
        private readonly IDepartmentsRepo _departmentsRepo;
        private readonly IMapper _mapper;

        public DepartmentAndRolesServices(IDepartmentsRepo departmentsRepo, IMapper mapper)
        {
            _departmentsRepo = departmentsRepo;
            _mapper = mapper;
        }

        public bool AddRoleToDepartment(int departmentId, string newRole)
        {
            return _departmentsRepo.SaveNewRole(departmentId, newRole);
        }

        public List<ViewDepartmentAndRolesDto> GetDepartmentsAndRoles()
        {
            var departmentsAndRolesData = _departmentsRepo.LoadDepartmentsAndRoles();
            var departmentAndRoles = _mapper.Map<List<ViewDepartmentAndRolesDto>>(departmentsAndRolesData);

            return departmentAndRoles;
        }
    }
}
