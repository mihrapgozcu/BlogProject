using AutoMapper;
using BlogProject.BLL.Services.Abstract;
using BlogProject.BLL.Services.Concrete;
using BlogProject.DAL.Entities;
using BlogProject.DAL.ViewModels.Roles;
using BlogProject.DAL.ViewModels.Users;
using BlogProject.Web.Consts;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{RoleConsts.Admin}")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly IValidator<AppRole> _validator;

        public RoleController(IRoleService roleService, IMapper mapper, IValidator<AppRole> validator)
        {
            _roleService = roleService;
            _mapper = mapper;
            _validator = validator;
        }


        public async Task<IActionResult> Index()
        {
            var roles = await _roleService.GetAllRoles();
            return View(roles);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateVM roleCreateVM)
        {
            var map = _mapper.Map<AppRole>(roleCreateVM);
            map.Name = roleCreateVM.RoleName;

            var validation = await _validator.ValidateAsync(map);
            
            if (!ModelState.IsValid)
            {
                return View(roleCreateVM);
            }

            var result = await _roleService.CreateRole(roleCreateVM);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Role", new { Area = "Admin" });
            }
            else
            {
                result.AddToIdentityModelState(this.ModelState);
                validation.AddToModelState(this.ModelState);
                return View(roleCreateVM);
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var role = await _roleService.GetAppRoleById(id);
            var map = _mapper.Map<RoleUpdateVM>(role);
            map.RoleName = role.ToString();
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleUpdateVM roleUpdateVM)
        {
            var role = await _roleService.GetAppRoleById(roleUpdateVM.Id);

            if (role == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(roleUpdateVM);
            }

            var map = _mapper.Map(roleUpdateVM, role);
            var validation = await _validator.ValidateAsync(map);

            if (!validation.IsValid)    //Bizim yazdığımız validation kontrolü.
            {
                validation.AddToModelState(this.ModelState);
                return View(roleUpdateVM);
            }

            role.Name = roleUpdateVM.RoleName;
            role.ConcurrencyStamp = Guid.NewGuid().ToString();
            var result = await _roleService.UpdateRole(roleUpdateVM);

            if (result.Succeeded)       //Identity kendi kontrolü.
            {
                return RedirectToAction("Index", "Role", new { Area = "Admin" });
            }
            else
            {
                result.AddToIdentityModelState(this.ModelState);
                return View(roleUpdateVM);
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var result = await _roleService.DeleteRole(id);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Role", new { Area = "Admin" });
            }
            else
            {
                result.AddToIdentityModelState(this.ModelState);
            }

            return NotFound();
        }
    }
}
