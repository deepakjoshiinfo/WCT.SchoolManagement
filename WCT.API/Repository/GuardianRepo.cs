using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WCT.API.Data;
using WCT.API.Models;

namespace WCT.API.Repository
{
    public class GuardianRepo
    {
        public IEnumerable<Guardian> Get()
        {
            var list = new List<Guardian>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = dbContext.guardians.AsEnumerable().Select(i => new Guardian(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public Guardian Get(int Id)
        {

            try
            {
                using (var dbContext = new SMSEntities())
                {
                    return new Guardian(dbContext.guardians.Where(i => i.Id == Id).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public Guardian Post(Guardian guardian)
        {
            var item = guardian.GetDataObject();
            using (var dbContext = new SMSEntities())
            {
                if (item.Id == 0)
                {
                    if (!IsAlreadyExist(item.Name))
                    {
                        dbContext.guardians.Add(item);
                        dbContext.SaveChanges();
                    }
                }
                else
                {
                    dbContext.Entry(item).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            guardian.Id = item.Id;
            return guardian;
        }
        private bool IsAlreadyExist(string name)
        {
            bool result = false;
            using (var dbContext = new SMSEntities())
            {
                var item = dbContext.genders.Where(i => i.Name.ToLower() == name.ToLower()).FirstOrDefault();
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
                var item = dbContext.genders.Where(i => i.Id == Id).FirstOrDefault();
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