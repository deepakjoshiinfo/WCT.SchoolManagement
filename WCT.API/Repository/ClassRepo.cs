using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WCT.API.Data;
using WCT.API.Models;

namespace WCT.API.Repository
{
    public class ClassRepo
    {
        public IEnumerable<Class> Get()
        {
            var list = new List<Class>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = dbContext.classes.AsEnumerable().Select(i => new Class(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public IEnumerable<Class> GetActive()
        {
            var list = new List<Class>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = dbContext.classes.Where(i=>i.IsActive==true).AsEnumerable().Select(i => new Class(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public Class Get(int Id)
        {

            try
            {
                using (var dbContext = new SMSEntities())
                {
                    return new Class(dbContext.classes.Where(i => i.Id == Id).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public Class Post(Class cls)
        {
            var item = cls.GetDataObject();
            using (var dbContext = new SMSEntities())
            {
                if (item.Id == 0)
                {
                    if (!IsAlreadyExist(item.Name))
                    {
                        dbContext.classes.Add(item);
                        dbContext.SaveChanges();
                        var list = new List<classsection>();
                        foreach (var section in cls.Sections)
                        {
                            if (section.IsSelected)
                            {
                                var classsection = new classsection() { ClassId = item.Id, SectionId = section.Id };
                                dbContext.classsections.Add(classsection);
                                dbContext.SaveChanges();
                            }
                        }
                    }
                }
                else
                {
                   
                    IEnumerable<classsection> list = dbContext.classsections.Where(i => i.ClassId == item.Id);
                    foreach (var itm in list)
                    {
                        dbContext.Entry(itm).State = EntityState.Deleted;
                    } 
                    list = new List<classsection>();
                    foreach (var section in cls.Sections)
                    {
                        if (section.IsSelected)
                        {
                            var classsection = new classsection() { ClassId = item.Id, SectionId = section.Id };
                            dbContext.classsections.Add(classsection);
                        }
                    }
                    dbContext.Entry(item).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            cls.Id = item.Id;
            return cls;
        }
        private bool IsAlreadyExist(string name)
        {
            bool result = false;
            using (var dbContext = new SMSEntities())
            {
                var item = dbContext.classes.Where(i => i.Name.ToLower() == name.ToLower()).FirstOrDefault();
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
                var item = dbContext.classes.Where(i => i.Id == Id).FirstOrDefault();
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