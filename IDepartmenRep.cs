using Portal.Core.Models;
using Portal.Infastration.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Interface
{
    public interface IDepartmenRep
    {
        Task<List<Department>>  GetAsync();
        Task<Department> GetByIdAsync(int id);

        Task CreatAsync(Department obj);
        Task UpdateAsync(Department obj);

        Task DeleteAsync(Department obj);
    }

}
