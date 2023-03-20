using ePizzeriaHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzeriaHub.Services.Interfaces
{
    public interface IPizzeriaService
    {
        IEnumerable<Pizzeria> GetPizzerias();
        Pizzeria GetPizzeria(int id);
        void AddPizzeria(Pizzeria pizzeria);
        void UpdatePizzeria(Pizzeria pizzeria);
        void DeletePizzeria(int id);
    }
}
