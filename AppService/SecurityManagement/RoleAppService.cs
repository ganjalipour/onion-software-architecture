using AutoMapper;
using Consulting.Common.Data;
using Consulting.Domains.Core.Service;
using Consulting.Domains.Core.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Consulting.Applications.AppService.ServiceDto.SecurityDto;

namespace Consulting.Applications.AppService.RoleManagement
{
    public class RoleAppService
    {
        public RoleService _roleService;
        private readonly IMapper _mapper;     
        private ITransactionManager _transactionManager;
        public RoleAppService(RoleService roleService, ITransactionManager transactionManager, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
            _transactionManager = transactionManager;
        }

        public RoleDto GetRoleOfMine()
        {
            // a sample code for mapping
            //var role = new Role() { RoleID = 1, CreateDate = DateTime.Now, RoleName = "kknjhb" };
            //var rlo = _mapper.Map<RoleDto>(role);
            

            var roleDto = new RoleDto { RoleName = _roleService.GetMyRole().RoleName };
            return roleDto;
        }

        public async Task<RoleDto> GetRoleOfMineAsync(int id)
        {
            var myrole = await _roleService.GetRoleAsync(id);
            var roleDto = new RoleDto { RoleName = myrole.RoleName };
            await _transactionManager.SaveAllAsync();
            return roleDto;
        }

             

        public async Task<RoleDto> CreateRoleAsync(RoleDto RoleDto)
        {
            var Role = _mapper.Map<Role>(RoleDto);

            await _roleService.CreateRoleAsync(Role);
            await _transactionManager.SaveAllAsync();
            return _mapper.Map<RoleDto>(Role);
        }

        public async Task<RoleDto> UpdateRoleAsync(RoleDto RoleDto)
        {
            var Role = _mapper.Map<Role>(RoleDto);
            await _roleService.UpdateRoleAsync(Role);
            await _transactionManager.SaveAllAsync();
            return _mapper.Map<RoleDto>(Role);
        }

        public async Task<IEnumerable<RoleDto>> GetRolesAsync()
        {
            var userList = await _roleService.GetRolesAsync();
            var RoleDtoList = _mapper.Map<IEnumerable<RoleDto>>(userList);
            await _transactionManager.SaveAllAsync();
            return RoleDtoList;
        }



        public async Task<RoleDto> GetRoleByID(int ID)
        {
            var Role = await _roleService.GetRoleAsync(ID);
            return _mapper.Map<RoleDto>(Role);

        }
        public async Task DeleteRoleAsync(RoleDto RoleDto)
        {
            var Role = _mapper.Map<Role>(RoleDto);
            await _roleService.RemoveRoleAsync(Role);
            await _transactionManager.SaveAllAsync();

        }

    }
}
