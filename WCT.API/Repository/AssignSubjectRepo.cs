using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WCT.API.Data;
using WCT.API.Models;

namespace WCT.API.Repository
{
    public class AssignSubjectRepo
    {
        public IEnumerable<AssignSubject> Get()
        {
            var list = new List<AssignSubject>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = dbContext.assignsubjects.AsEnumerable().Select(i => new AssignSubject(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public IEnumerable<AssignSubject> GetActive()
        {
            var list = new List<AssignSubject>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = dbContext.assignsubjects.AsEnumerable().Select(i => new AssignSubject(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public AssignSubject Get(int Id)
        {

            try
            {
                using (var dbContext = new SMSEntities())
                {
                    return new AssignSubject(dbContext.assignsubjects.Where(i => i.Id == Id).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public AssignSubject Post(AssignSubject assignsubject)
        {
            var item = assignsubject.GetDataObject();
            using (var dbContext = new SMSEntities())
            {
                if (item.Id == 0)
                {
                    
                    
                        dbContext.assignsubjects.Add(item);
                        dbContext.SaveChanges();
                    
                }
                else
                {
                    dbContext.Entry(item).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            assignsubject.Id = item.Id;
            return assignsubject;
        }
       
        public bool Delete(int Id)
        {
            bool result = false;
            using (var dbContext = new SMSEntities())
            {
                var item = dbContext.assignsubjects.Where(i => i.Id == Id).FirstOrDefault();

                dbContext.assignsubjects.Remove(item);
                dbContext.SaveChanges();
                result = true;
            }
            return result;
        }
        public IEnumerable<AssignSubject> SearchTeachers(int classId, int sectionId)
        {
            var list = new List<AssignSubject>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = dbContext.assignsubjects.Where(i => (i.ClassId == classId && i.SectionId == sectionId && i.IsActive==true)).AsEnumerable().Select(i => new AssignSubject(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
    }
}