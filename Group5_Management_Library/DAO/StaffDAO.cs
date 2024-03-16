using Group5_Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance = null;
        private static readonly object instanceLock = new object();
        public static StaffDAO Instance
        {
            //Singlestone pattern
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StaffDAO();
                    }
                    return instance;
                }
            }
        }



        public IEnumerable<Staff> GetStaffList(string sortBy)
        {
            ///ham sort by name 
            using var context = new MyTravelDBContext();
            List<Staff> model = context.Staffs.ToList();
            try
            {
                switch (sortBy)
                {
                    case "name":
                        model = model.OrderBy(o => o.StaffId).ToList();
                        break;
                    case "namedesc":
                        model = model.OrderByDescending(o => o.StaffName).ToList();
                        break;

                    case "id":
                        model = model.OrderBy(o => o.StaffId).ToList();
                        break;
                    case "iddesc":
                        model = model.OrderByDescending(o => o.StaffId).ToList();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return model;
        }

        public Staff GetStaffByID(int id)
        {
            Staff kh = null;
            try
            {
                using var context = new MyTravelDBContext();
                kh = context.Staffs.SingleOrDefault(k => k.StaffId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return kh;
        }

        public IEnumerable<Staff> GetStaffBySearchName(string name, string CityName, string sortBy)
        {


            //ham sort by name  
            var context = new MyTravelDBContext();
            List<Staff> model = context.Staffs.ToList();

            try
            {
                if (!String.IsNullOrEmpty(name))
                {
                    model = model.Where(x => x.StaffName.ToLower().Contains(name)).ToList();
                }
                if (true)
                {
                    //model = model.Where(x => x.DiaChi.ToLower().Contains()).ToList();

                    switch (sortBy)
                    {
                        case "name":
                            model = model.OrderBy(o => o.StaffName).ToList();
                            break;
                        case "namedesc":
                            model = model.OrderByDescending(o => o.StaffName).ToList();
                            break;
                        case "address":
                            model = model.OrderBy(o => o.DiaChi).ToList();
                            break;
                        case "addressdesc":
                            model = model.OrderByDescending(o => o.DiaChi).ToList();
                            break;
                        case "id":
                            model = model.OrderBy(o => o.StaffId).ToList();
                            break;
                        case "iddesc":
                            model = model.OrderByDescending(o => o.StaffId).ToList();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return model;
        }


        public void AddNew(Staff kh)
        {

            try
            {
                Staff _kh = GetStaffByID(kh.StaffId);
                if (_kh == null)
                {
                    using var context = new MyTravelDBContext();
                    context.Staffs.Add(kh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Staff is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Staff kh)
        {

            try
            {
                Staff _kh = GetStaffByID(kh.StaffId);
                if (_kh != null)
                {
                    using var context = new MyTravelDBContext();
                    context.Staffs.Update(kh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Staff does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int id)
        {
            try
            {
                Staff _kh = GetStaffByID(id);
                if (_kh != null)
                {
                    using var context = new MyTravelDBContext();
                    context.Staffs.Remove(_kh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Staff does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Staff> RemoveStaffSelected(IEnumerable<int> DeleteList)
        {
            using var context = new MyTravelDBContext();
            var DeleteCatList = context.Staffs.Where(z => DeleteList.Contains(z.StaffId)).ToList();
            context.Staffs.RemoveRange(DeleteCatList);
            context.SaveChanges();
            return DeleteCatList;
        }
    }
}
