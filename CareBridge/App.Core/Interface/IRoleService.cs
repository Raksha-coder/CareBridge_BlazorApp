using Domain.DataModel.Entity;
using Domain.ReponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Interface
{
    public interface IRoleService
    {
        public Task<List<Role>> GetAllRoleAsync();
    }
}
