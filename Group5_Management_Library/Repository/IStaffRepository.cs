using Group5_Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.Repository
{
    public interface  IStaffRepository
    {
        IEnumerable<Staff> GetStaff(string sortBy);
        IEnumerable<Staff> GetStaffByName(string name, string CityName, string sortBy);
        Staff GetStaffByID(int id);
        void InsertStaff(Staff kh);
        void UpdateStaff(Staff kh);
        void DeleteStaff(int id);
        IEnumerable<Staff> DeleteSelectedStaff(IEnumerable<int> DeleteList);
    }
}
