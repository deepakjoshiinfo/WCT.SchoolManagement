using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WCT.API.Data;
using WCT.API.Models;

namespace WCT.API.Repository
{
    public class CategoryRepo
    {
        public IEnumerable<Category> Get()
        {
            var list = new List<Category>();
            try
            {
                using (var dbContext = new SMSEntities())
                {

                    list= dbContext.categories.AsEnumerable().Select(i => new Category(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public IEnumerable<Category> GetActive()
        {
            var list = new List<Category>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = dbContext.categories.Where(i=>i.IsActive==true).AsEnumerable().Select(i => new Category(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public Category Get(int Id)
        {

            try
            {
                using (var dbContext = new SMSEntities())
                {
                    return new Category(dbContext.categories.Where(i => i.Id == Id).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public Category Post(Category category)
        {
            var item = category.GetDataObject();
            using (var dbContext = new SMSEntities())
            {
                if (item.Id == 0)
                {
                    if (!IsAlreadyExist(item.Name))
                    {
                        dbContext.categories.Add(item);
                        dbContext.SaveChanges();
                    }
                }
                else
                {
                    dbContext.Entry(item).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            category.Id = item.Id;
            return category;
        }
        private bool IsAlreadyExist(string name)
        {
            bool result = false;
            using (var dbContext = new SMSEntities())
            {
                var item = dbContext.categories.Where(i => i.Name.ToLower() == name.ToLower()).FirstOrDefault();
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
                var item = dbContext.categories.Where(i => i.Id == Id).FirstOrDefault();
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