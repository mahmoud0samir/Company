using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portal.Core.Interface;
using Portal.Core.Models;
using Portal.Infastration.Entity;

namespace PortalDEmoooo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepoistory employee;
        private readonly IDepartmenRep department;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeRepoistory employee , IDepartmenRep department ,IMapper mapper)
        {
            this.employee = employee;
            this.department = department;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var emps = await employee.GetAsync(emp =>emp.IsDeleted ==false && emp.IsActive == true);
            var data = mapper.Map<IEnumerable<EmployeeVm>>(emps);

            return View(data);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            
            var emp = await employee.GetByIdAsync(emp =>emp.id == id && emp.IsDeleted == false && emp.IsActive == true);
            ViewBag.Departmentlist = new SelectList(await department.GetAsync(), "ID", "Name");
            var data = mapper.Map<EmployeeVm>(emp);
            return View(data);
        }





        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {

            var emps = await employee.GetByIdAsync(emp => emp.id == id && emp.IsDeleted == false && emp.IsActive == true);
            var data = mapper.Map<EmployeeVm>(emps);
            ViewBag.Departmentlist = new SelectList(await department.GetAsync(), "ID", "Name" ,data.DepartmentID);

            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(EmployeeVm model)
        {

            try
            {
                ViewBag.Departmentlist = new SelectList(await department.GetAsync(), "ID", "Name",model.DepartmentID);


                if (ModelState.IsValid)
                    return View(model);

                var data = mapper.Map<Employee>(model);

                if (data != null)
                {
                    await employee.UpdateAsync(data);

                }


            }
            catch (Exception)
            {

                TempData["Error"] = "";
            }
            return RedirectToAction("Index", "Employee");

        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var emps = await employee.GetByIdAsync(emp => emp.id == id && emp.IsDeleted == false && emp.IsActive == true);
            var data = mapper.Map<EmployeeVm>(emps);

            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeVm model)
        {

            try
            {


                var data = mapper.Map<Employee>(model);

                await employee.DeleteAsync(data);



            }
            catch (Exception)
            {

                TempData["Error"] = "";
            }
            return RedirectToAction("Index", "Employee");

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Departmentlist = new SelectList(await department.GetAsync(),"ID","Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVm model)
        {

            try
            {
                ViewBag.Departmentlist = new SelectList(await department.GetAsync(), "ID", "Name");

                if (!ModelState.IsValid)
                    return View(model);


                var data = mapper.Map<Employee>(model);
                await employee.CreatAsync(data);





            }
            catch (Exception)
            {

                TempData["Error"] = "";
            }
            return RedirectToAction("Index", "Employee");

        }
    }
}
