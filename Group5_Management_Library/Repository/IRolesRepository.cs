
using Group5_Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.Repository
{
    public interface IRolesRepository
    {
            /*   IEnumerable<Role> GetAll();*/
        void Insert(Role role);
        void Update(Role role);
        Role GetById(int id);
        void Delete(Role role);
    }
}
