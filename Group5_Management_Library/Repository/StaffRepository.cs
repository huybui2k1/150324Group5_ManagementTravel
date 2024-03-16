
using Group5_Management_Library.DAO;
using Group5_Management_Library.Models;

namespace Group5_Management_Library.Repository
{
    public class StaffRepository : IStaffRepository
    {

        public IEnumerable<Staff> GetStaff(string sortBy) => StaffDAO.Instance.GetStaffList(sortBy);
        public IEnumerable<Staff> GetStaffByName(string name, string CityName, string sortBy) => StaffDAO.Instance.GetStaffBySearchName(name, CityName, sortBy);
        public Staff GetStaffByID(int id) => StaffDAO.Instance.GetStaffByID(id);
        public void InsertStaff(Staff kh) => StaffDAO.Instance.AddNew(kh);
        public void UpdateStaff(Staff kh) => StaffDAO.Instance.Update(kh);
        public void DeleteStaff(int id) => StaffDAO.Instance.Remove(id);
        public IEnumerable<Staff> DeleteSelectedStaff(IEnumerable<int> DeleteList) => StaffDAO.Instance.RemoveStaffSelected(DeleteList);
    }
}