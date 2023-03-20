using ePizzeriaHub.Entities;
using ePizzeriaHub.Services.Implementations;
using ePizzeriaHub.Services.Interfaces;
using ePizzeriaHub.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ePizzeriaHub.WebUI.Areas.Admin.Controllers
{
    public class PizzeriaController : BaseController
    {
        private IPizzeriaService _pizzeriaService;
        public PizzeriaController(IPizzeriaService pizzeriaService) 
        {

            _pizzeriaService = pizzeriaService;

        }
        public IActionResult Pizzeria()
        {
            var data = _pizzeriaService.GetPizzerias();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Pizzeria pizzeria)
        {
            try
            {
                Pizzeria myPizzeria = new Pizzeria { Name = pizzeria.Name, Location = pizzeria.Location, PostCode = pizzeria.PostCode };
                _pizzeriaService.AddPizzeria(myPizzeria);
            }
            catch(Exception ex)
            {
                throw;
            }
            return RedirectToAction("Pizzeria");
        }


        public IActionResult Edit(int id)
        {
             Pizzeria pizzeria = _pizzeriaService.GetPizzeria(id);
            
            return View("Create", pizzeria);
        }

        [HttpPost]
        public IActionResult Edit(Pizzeria model)
        {
            _pizzeriaService.UpdatePizzeria(model);
            return RedirectToAction("Pizzeria");
        }

        public IActionResult Delete(int id)
        {
            _pizzeriaService.DeletePizzeria(id);
            return RedirectToAction("Pizzeria");
        }
    }
}
