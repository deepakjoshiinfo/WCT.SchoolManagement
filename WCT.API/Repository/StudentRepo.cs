using Elmah;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WCT.API.Data;
using WCT.API.Models;

namespace WCT.API.Repository
{
    public class StudentRepo:BaseRepo
    {
        public IEnumerable<Student> Get()
        {
            var list = new List<Student>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list= dbContext.students.AsEnumerable().Select(i => new Student(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public IEnumerable<Student> GetActive()
        {
            var list = new List<Student>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = dbContext.students.Where(i=>i.IsActive==true).AsEnumerable().Select(i => new Student(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public Student Get(int Id)
        {
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    return new Student(dbContext.students.Where(i => i.Id == Id).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public Student Post(Student student)
        {
            try
            {
                GuardianRepo guardianRepo = new GuardianRepo();
                if (student.FatherId == null)
                {
                    var guardian = student.Father;
                    guardian.RelationId = 1;
                    var father = guardianRepo.Post(guardian);
                    student.FatherId = father.Id;
                }
                if (student.MotherId == null)
                {
                    var guardian = student.Mother;
                    guardian.RelationId = 2;
                    var mother = guardianRepo.Post(guardian);
                    student.MotherId = mother.Id;
                    student.GuardianId = mother.Id;
                    student.Guardian = mother;
                }
                var item =student.GetDataObject(); 

                using (var dbContext = new SMSEntities())
                {
                    if (item.Id == 0)
                    {
                        if (!IsAlreadyExist(item.Email))
                        {
                            item.CreatedBy = 1;
                            item.CreatedDate = DateTime.Now;
                            dbContext.students.Add(item);
                            dbContext.SaveChanges();
                        }
                    }
                    else
                    {
                        item.ModifiedBy = student.CreatedBy;
                        item.ModifiedDate = student.CreatedDate;
                        dbContext.Entry(item).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }
                student.Id = item.Id;
            }
            catch(Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
            }
            return student;
        }
        private bool IsAlreadyExist(string email)
        {
            bool result = false;
            using (var dbContext = new SMSEntities())
            {
                var item = dbContext.students.Where(i => i.Email.ToLower() == email.ToLower()).FirstOrDefault();
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
                var item = dbContext.students.Where(i => i.Id == Id).FirstOrDefault();
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