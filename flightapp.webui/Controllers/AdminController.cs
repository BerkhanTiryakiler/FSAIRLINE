using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using flightapp.business.Abstract;
using flightapp.entity;
using flightapp.webui.Extensions;
using flightapp.webui.Identity;
using flightapp.webui.Models;

namespace flightapp.webui.Controllers
{
    // sadikturan, efeturan, yigitbilgi => admin
    // adabilgi => customer
    [Authorize(Roles="admin")]
    public class AdminController: Controller
    {
        private IFlightService _flightService;
        private ICategoryService _categoryService;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        public AdminController(IFlightService flightService,
                               ICategoryService categoryService,
                               RoleManager<IdentityRole> roleManager,
                               UserManager<User> userManager)
        {
            _flightService = flightService;
            _categoryService = categoryService;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user!=null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles.Select(i=>i.Name);

                ViewBag.Roles = roles;
                return View(new UserDetailsModel(){
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    SelectedRoles = selectedRoles
                });
            }
            return Redirect("~/admin/user/list");
        }


        [HttpPost]
        public async Task<IActionResult> UserEdit(UserDetailsModel model,string[] selectedRoles)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if(user!=null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.EmailConfirmed = model.EmailConfirmed;

                    var result = await _userManager.UpdateAsync(user);

                    if(result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        selectedRoles = selectedRoles?? new string[]{};
                        await _userManager.AddToRolesAsync(user,selectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user,userRoles.Except(selectedRoles).ToArray<string>());

                        return Redirect("/admin/user/list");
                    }
                }
                return Redirect("/admin/user/list");
            }

            return View(model);

        }
        
        public IActionResult UserList()
        {
            return View(_userManager.Users);
        }

        public async Task<IActionResult> RoleEdit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var members = new List<User>();
            var nonmembers = new List<User>();

            foreach (var user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user,role.Name)
                                ?members:nonmembers;
                list.Add(user);
            }
            var model = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel model)
        {
            if(ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[]{})
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user!=null)
                    {
                        var result = await _userManager.AddToRoleAsync(user,model.RoleName);
                        if(!result.Succeeded)
                        {
                              foreach (var error in result.Errors)
                              { 
                                ModelState.AddModelError("", error.Description);  
                              }  
                        }
                    }
                }
          
                foreach (var userId in model.IdsToDelete ?? new string[]{})
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user!=null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user,model.RoleName);
                        if(!result.Succeeded)
                        {
                              foreach (var error in result.Errors)
                              { 
                                ModelState.AddModelError("", error.Description);  
                              }  
                        }
                    }
                }
            }
            return Redirect("/admin/role/"+model.RoleId);
        }
        
        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }

        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]        
        public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if(result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                }
            }
            return View(model);
        }
        
        
        public async Task<IActionResult> flightList()
        {
            var flights = await _flightService.GetAll();
            return View(new flightListViewModel()
            {
                Flights = flights
            });
        }
        public async Task<IActionResult> CategoryList()
        {
            var categories = await _categoryService.GetAll();
            return View(new CategoryListViewModel()
            {
                Categories = categories
            });
        }
        public IActionResult flightCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult flightCreate(FlightModel model)
        {
            if(ModelState.IsValid)
            {
                var entity = new Flight()
                {
                    Name = model.Name,
                    Url = model.Url,
                    Price = model.Price,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl
                };
                
                if(_flightService.Create(entity))
                {                    
                    TempData.Put("message", new AlertMessage()
                    {
                        Title="kayıt eklendi",
                        Message="kayıt eklendi",
                        AlertType="success"
                    });
                    return RedirectToAction("flightList");
                }
                TempData.Put("message", new AlertMessage()
                {
                    Title="hata",
                    Message=_flightService.ErrorMessage,
                    AlertType="danger"
                });                

                return View(model);
            }            
            return View(model);         
        }
        public IActionResult CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryCreate(CategoryModel model)
        {
             if(ModelState.IsValid)
            {
                var entity = new Category()
                {
                    Name = model.Name,
                    Url = model.Url            
                };
                
                _categoryService.Create(entity);

                TempData.Put("message", new AlertMessage()
                {
                    Title="kayıt eklendi.",
                    Message=$"{entity.Name} isimli category eklendi.",
                    AlertType="success"
                });             

                return RedirectToAction("CategoryList");
            }
            return View(model);
        }
        public async Task<IActionResult> flightEdit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var entity = _flightService.GetByIdWithCategories((int)id);

            if(entity==null)
            {
                 return NotFound();
            }

            var model = new FlightModel()
            {
                flightId = entity.FlightId,
                Name = entity.Name,
                Url = entity.Url,
                Price = entity.Price,
                ImageUrl= entity.ImageUrl,
                Description = entity.Description,
                IsApproved = entity.IsApproved,
                IsHome = entity.IsHome,
                SelectedCategories = entity.FlightCategories.Select(i=>i.Category).ToList()
            };

            ViewBag.Categories = await _categoryService.GetAll();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> flightEdit(FlightModel model,int[] categoryIds,IFormFile file)
        {
            if(ModelState.IsValid)
            {        
                var entity =  await _flightService.GetById(model.flightId);
                if(entity==null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;
                entity.Price = model.Price;
                entity.Url = model.Url;
                entity.Description = model.Description;
                entity.IsHome = model.IsHome;
                entity.IsApproved = model.IsApproved;

                if(file!=null)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    entity.ImageUrl = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\img",randomName);

                    using(var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                if(_flightService.Update(entity,categoryIds))
                {                    
                     TempData.Put("message", new AlertMessage()
                    {
                        Title="kayıt güncellendi",
                        Message="kayıt güncellendi",
                        AlertType="success"
                    });  
                    return RedirectToAction("flightList");
                }
                 TempData.Put("message", new AlertMessage()
                    {
                        Title="hata",
                        Message=_flightService.ErrorMessage,
                        AlertType="danger"
                    }); 
            }
            ViewBag.Categories = await _categoryService.GetAll();
            return View(model);
        }
        public IActionResult CategoryEdit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var entity = _categoryService.GetByIdWithFlights((int)id);

            if(entity==null)
            {
                 return NotFound();
            }

            var model = new CategoryModel()
            {
                CategoryId = entity.CategoryId,
                Name = entity.Name,
                Url = entity.Url,
                flights = entity.FlightCategories.Select(p=>p.Flight).ToList()
            };
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> CategoryEdit(CategoryModel model)
        {
            if(ModelState.IsValid)
            {
                var entity = await _categoryService.GetById(model.CategoryId);
                if(entity==null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;
                entity.Url = model.Url;

                _categoryService.Update(entity);

                var msg = new AlertMessage()
                {            
                    Message = $"{entity.Name} isimli category güncellendi.",
                    AlertType = "success"
                };

                TempData["message"] =  JsonConvert.SerializeObject(msg);

                return RedirectToAction("CategoryList");
            }
            return View(model);
        }
        public async Task<IActionResult> Deleteflight(int flightId)
        {
            var entity = await _flightService.GetById(flightId);

            if(entity!=null)
            {
                _flightService.Delete(entity);
            }

              var msg = new AlertMessage()
            {            
                Message = $"{entity.Name} isimli ürün silindi.",
                AlertType = "danger"
            };

            TempData["message"] =  JsonConvert.SerializeObject(msg);

            return RedirectToAction("flightList");
        }
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var entity =  await _categoryService.GetById(categoryId);

            if(entity!=null)
            {
                _categoryService.Delete(entity);
            }

              var msg = new AlertMessage()
            {            
                Message = $"{entity.Name} isimli category silindi.",
                AlertType = "danger"
            };

            TempData["message"] =  JsonConvert.SerializeObject(msg);

            return RedirectToAction("CategoryList");
        }
    
        [HttpPost]
        public IActionResult DeleteFromCategory(int flightId,int categoryId)
        {
            _categoryService.DeleteFromCategory(flightId,categoryId);
            return Redirect("/admin/categories/"+categoryId);
        }
    }
}