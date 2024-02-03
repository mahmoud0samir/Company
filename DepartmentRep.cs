using Microsoft.EntityFrameworkCore;
using Portal.Core.Interface;
using Portal.Core.Models;
using Portal.Infastration.Database;
using Portal.Infastration.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Portal.Core.Repiostry
{
    public class DepartmentRep : IDepartmenRep
    {

        private readonly ApplicationContext db;
        public DepartmentRep(ApplicationContext db)
        {
            this.db = db;
        }


        public async Task<List<Department>> GetAsync()
        {
            var data = await db.Departments.ToListAsync();

            
            return data;       
        }

        public async Task<Department> GetByIdAsync(int id)
        {
           
                var data = await db.Departments.Where(a =>a.ID == id).SingleOrDefaultAsync();
            if (data == null)
                throw new NullReferenceException("");
            return data;

        }
        public async Task CreatAsync(Department obj)
        {
 
          await  db.Departments.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Department obj)
        {

            var olddata = db.Departments.Find(obj.ID);
            if (olddata != null)
            {
                db.Departments.Remove(olddata);
            }


            await db.SaveChangesAsync();

        }

        public async Task UpdateAsync(Department obj)
        {
            var olddata = db.Departments.Find(obj.ID);
            if (olddata != null)
            {
                olddata.Name = obj.Name;
                olddata.Code = obj.Code;
                await db.SaveChangesAsync();
            }
        }

    }
}
