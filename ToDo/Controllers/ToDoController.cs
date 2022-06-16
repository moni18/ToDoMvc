using BusinessLogic;
using Data.Domain;
using Data.Domain.Models;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoService _toDoService;
        //private UserManager<ApplicationUser> manager;

        public ToDoController(ToDoService toDoService)
        {
            _toDoService = toDoService;

            //manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }
        public async Task<IActionResult> Index()
        {
            var items = await _toDoService.FetchAsync();
            return View("List", items);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("Create", new ToDoViewModel
            {                
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToDoViewModel todo)
        {
            await _toDoService.CreateAsync(todo);
            return Redirect("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var item = await _toDoService.FetchAsync(id);
            return View("Details", item);
        }

        [HttpGet]       
        public async Task<IActionResult> Delete(int id)
        {
            await _toDoService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]        
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _toDoService.FetchAsync(id);
            return View("Edit", item);
        }

        [HttpPost]       
        public async Task<IActionResult> Edit(ToDoViewModel reception)
        {
            await _toDoService.UpdateAsync(reception);
            return RedirectToAction("Index");
        }

        [HttpPost]        
        public async Task<IActionResult> Close(int id)
        {
            await _toDoService.CloseAsync(id);
            return RedirectToAction("Index");
        }
    }
}
