using Microsoft.EntityFrameworkCore;
using Portal.Core.Interface;
using Portal.Infastration.Database;
using Portal.Infastration.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Repiostry
{
    public class EmployeeRep : IEmployeeRepoistory
    {

        private readonly ApplicationContext db;
        public EmployeeRep(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<List<Employee>> GetAsync(Expression<Func<Employee, bool>> filter)
        {
            var data = await db.Employees.Include(emp =>emp.department).Where(filter).ToListAsync();


            return data;
        }

        public async Task<Employee> GetByIdAsync(Expression<Func<Employee, bool>> filter)
        {

            var data = await db.Employees.Include(emp => emp.department).Where(filter).SingleOrDefaultAsync();
            if (data == null)
                throw new NullReferenceException("");
            return data;

        }
        public async Task CreatAsync(Employee obj)
        {

            await db.Employees.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee obj)
        {

            var olddata = db.Employees.Find(obj.id);
            if (olddata != null)
            {
                db.Employees.Remove(olddata);
            }


            await db.SaveChangesAsync();

        }

        public async Task UpdateAsync(Employee obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();

        }
    }
}
