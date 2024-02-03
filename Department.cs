using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Portal.Core.Interface;
using Portal.Core.Models;
using Portal.Core.Repiostry;
using Portal.Infastration.Database;
using Portal.Infastration.Entity;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PortalDEmoooo.Controllers
{
    public class DepartmentController : Controller
    {

        //DepartmentRep department = new DepartmentRep();

        private readonly IDepartmenRep department;
        private readonly IMapper mapper;

        public DepartmentController(IDepartmenRep department, IMapper mapper)
        {
            this.department = department;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var depts = await department.GetAsync();
            var data = mapper.Map<IEnumerable<DepartmentVM>>(depts);

            return View(data);
        }
        public async Task<IActionResult> Details(int ID)
        {
            var dpt = await department.GetByIdAsync(ID);
            var data =mapper.Map<DepartmentVM>(dpt);    
            return View(data);
        }

    

  

        [HttpGet]
        public async Task<IActionResult> Update(int ID)
        {
            var depts = await department.GetByIdAsync(ID);
            var data = mapper.Map<DepartmentVM>(depts);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DepartmentVM model) {

            try
            {

                if (ModelState.IsValid)
                return View(model);

                var data = mapper.Map<Department>(model);

                if (data != null)
                {
                    await department.UpdateAsync(data);

                }


            }
            catch (Exception)
            {

                TempData["Error"] = "";
            }
            return RedirectToAction("Index", "Department");

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int ID)
        {
            var depts = await department.GetByIdAsync(ID);
            var data = mapper.Map<DepartmentVM>(depts);

            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DepartmentVM model)
        {

            try
            {


                var data = mapper.Map<Department>(model);

                await department.DeleteAsync(data);



            }
            catch (Exception)
            {

                TempData["Error"] = "";
            }
            return RedirectToAction("Index", "Department");

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentVM model)
        {

            try
            {

                if (!ModelState.IsValid)
                    return View(model);


                var data = mapper.Map<Department>(model); 
                    await department.CreatAsync(data);

                



            }
            catch (Exception)
            {

                TempData["Error"] = "";
            }
            return RedirectToAction("Index", "Department");

        }
    }
}
