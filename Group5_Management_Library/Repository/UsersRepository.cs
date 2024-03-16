using Group5_Management_Library.DAO;
using Group5_Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.Repository
{
    public class UsersRepository : IUsersRepository
    {
       // public IEnumerable<User> GetAll() => UsersDAO.Instance.GetAll();
        public void Insert(User user, UserDetail userDetail) => UsersDAO.Instance.Insert(user, userDetail);
        public void Update(User user, UserDetail userDetail) => UsersDAO.Instance.Update(user, userDetail);
        public User GetById(int id) => UsersDAO.Instance.GetById(id);
        public void Delete(User user) => UsersDAO.Instance.Delete(user);
        public IEnumerable<Role> GetAllRoles() => UsersDAO.Instance.GetAllRoles();
        public bool ChangeStatus(int id) => UsersDAO.Instance.ChangeStatus(id);
        public IEnumerable<UserDetail> GetUserDetailAll() => UsersDAO.Instance.GetUserDetailAll();
        public void InsertUser(User user) => UsersDAO.Instance.InsertUser(user);
        public void InsertUserDetail(UserDetail userDetail) => UsersDAO.Instance.InsertUserDetail(userDetail);
        public void UpdateUser(User user) => UsersDAO.Instance.UpdateUser(user);
        public void UpdateUserDetail(UserDetail userDetail) => UsersDAO.Instance.UpdateUserDetail(userDetail);
        public UserDetail GetByUserDetailId(int? id) => UsersDAO.Instance.GetByUserDetailId(id);

        public List<UserDetail> GetUserDetailByKeyword(string keyword) => UsersDAO.Instance.GetUserDetailByKeyword(keyword);
        public List<User> GetUserByKeyword(string keyword, string sortBy, int? roleId) => UsersDAO.Instance.GetUserByKeyword(keyword, sortBy, roleId);
        public User CheckLogin(string userName, string password) => UsersDAO.Instance.CheckLogin(userName, password);
        public User GetByUserName(string userName) => UsersDAO.Instance.GetByUserName(userName);
    }
}
