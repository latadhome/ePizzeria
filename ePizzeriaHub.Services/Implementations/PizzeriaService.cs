using ePizzeriaHub.Entities;
using ePizzeriaHub.Repositories.Interfaces;
using ePizzeriaHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzeriaHub.Services.Implementations
{
    public class PizzeriaService : IPizzeriaService
    {
        private readonly IRepository<Pizzeria> _pizzeriaRepo;
        public PizzeriaService(IRepository<Pizzeria> pizzeriaRepo)
        {
            _pizzeriaRepo = pizzeriaRepo;
        }
        public void AddPizzeria(Entities.Pizzeria pizzeria)
        {
            _pizzeriaRepo.Add(pizzeria);
            _pizzeriaRepo.SaveChanges();
        }

        public void DeletePizzeria(int id)
        {
           _pizzeriaRepo.Delete(id);
            _pizzeriaRepo.SaveChanges();
        }

        public Entities.Pizzeria GetPizzeria(int id)
        {
            return _pizzeriaRepo.Find(id);
        }

        public IEnumerable<Entities.Pizzeria> GetPizzerias()
        {
           return  _pizzeriaRepo.GetAll().OrderBy(p => p.Id);
        }

        public void UpdatePizzeria(Entities.Pizzeria pizzeria)
        {
            _pizzeriaRepo.Update(pizzeria);
            _pizzeriaRepo.SaveChanges();
        }
    }
}
