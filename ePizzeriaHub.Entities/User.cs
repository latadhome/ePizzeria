using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzeriaHub.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }

        [NotMapped] // excluded from the DB mapping
        public string[] Roles { get; set; } 
    }
}
