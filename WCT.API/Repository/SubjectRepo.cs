using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WCT.API.Data;
using WCT.API.Models;

namespace WCT.API.Repository
{
    public class SubjectRepo
    {
        public IEnumerable<Subject> Get()
        {
            var list = new List<Subject>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = dbContext.subjects.AsEnumerable().Select(i => new Subject(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public IEnumerable<Subject> GetActive()
        {
            var list = new List<Subject>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = dbContext.subjects.Where(i => i.IsActive == true).AsEnumerable().Select(i => new Subject(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public Subject Get(int Id)
        {

            try
            {
                using (var dbContext = new SMSEntities())
                {
                    return new Subject(dbContext.subjects.Where(i => i.Id == Id).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public Subject Post(Subject subject)
        {
            var item = subject.GetDataObject();
            using (var dbContext = new SMSEntities())
            {
                if (item.Id == 0)
                {
                    if (!IsAlreadyExist(item.Name))
                    {
                        dbContext.subjects.Add(item);
                        dbContext.SaveChanges();
                    }
                }
                else
                {
                    dbContext.Entry(item).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            subject.Id = item.Id;
            return subject;
        }
        private bool IsAlreadyExist(string name)
        {
            bool result = false;
            using (var dbContext = new SMSEntities())
            {
                var item = dbContext.subjects.Where(i => i.Name.ToLower() == name.ToLower()).FirstOrDefault();
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
                var item = dbContext.subjects.Where(i => i.Id == Id).FirstOrDefault();
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