using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var role = roleManager.Roles;
            return View(role);
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleVM model)
        {
            if (ModelState.IsValid)
            {
                var role =new IdentityRole()
                {
                    Name=model.RoleName,
                };

                var result =await roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors) 
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }

            }

            return View(model);
        }

        public async Task<IActionResult> EditRole(string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);

            var data = new RoleVM();

            data.RoleName = role.Name;
           

            return View(data);
        }



        [HttpPost]
        public async Task<IActionResult> EditRole(RoleVM model)
        {

            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(model.Id);

                role.Name = model.RoleName;

                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }


            }




            return View(model);
        }


        public async Task<IActionResult> DeleteRole(string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);


            var data = new RoleVM()
            {
                Id = role.Id,
                RoleName = role.Name
            };

            return View(data);
        }



        [HttpPost]
        public async Task<IActionResult> DeleteRole(RoleVM model)
        {

            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(model.Id);


                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }


            }

            return View(model);
        }

    }
}
