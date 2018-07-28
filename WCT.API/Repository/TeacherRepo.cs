using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WCT.API.Data;
using WCT.API.Models;

namespace WCT.API.Repository
{
    public class TeacherRepo
    {
        public IEnumerable<Teacher> Get()
        {
            var list = new List<Teacher>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = dbContext.teachers.AsEnumerable().Select(i => new Teacher(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public IEnumerable<Teacher> GetActive()
        {
            var list = new List<Teacher>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = dbContext.teachers.Where(i=>i.IsActive==true).AsEnumerable().Select(i => new Teacher(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public Teacher Get(int Id)
        {

            try
            {
                using (var dbContext = new SMSEntities())
                {
                    return new Teacher(dbContext.teachers.Where(i => i.Id == Id).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public Teacher Post(Teacher teacher)
        {
            var item = teacher.GetDataObject();
            using (var dbContext = new SMSEntities())
            {
                if (item.Id == 0)
                {
                    if (!IsAlreadyExist(item.Name))
                    {
                        dbContext.teachers.Add(item);
                        dbContext.SaveChanges();
                    }
                }
                else
                {
                    dbContext.Entry(item).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            teacher.Id = item.Id;
            return teacher;
        }
        private bool IsAlreadyExist(string name)
        {
            bool result = false;
            using (var dbContext = new SMSEntities())
            {
                var item = dbContext.teachers.Where(i => i.Name.ToLower() == name.ToLower()).FirstOrDefault();
                if (item != null)
                {
                    result = true;
                }
            }
            return result;
        }
        public bool Delete(int Id)
        {
            bool result = false;
            using (var dbContext = new SMSEntities())
            {
                var item = dbContext.teachers.Where(i => i.Id == Id).FirstOrDefault();
                if (item != null)
                {
                    item.IsActive = false;
                }
                dbContext.Entry(item).State = EntityState.Modified;
                dbContext.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}