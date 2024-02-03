using Portal.Infastration.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Interface
{
    public interface IEmployeeRepoistory
    {

        Task<List<Employee>> GetAsync(Expression<Func<Employee,bool>>filter);
        Task<Employee> GetByIdAsync(Expression<Func<Employee, bool>> filter);

        Task CreatAsync(Employee obj);
        Task UpdateAsync(Employee obj);

        Task DeleteAsync(Employee obj);
    }
}
