﻿using App.Core.Interface;
using Domain.ReponseModel;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public Task<JsonModel> GetAllRoleAsync()
        {
            return _roleRepository.GetAllRoleAsync();
        }
    }
}
