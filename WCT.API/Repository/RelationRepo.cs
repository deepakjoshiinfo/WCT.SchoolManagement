using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WCT.API.Data;
using WCT.API.Models;

namespace WCT.API.Repository
{
    public class RelationRepo
    {
        public IEnumerable<Relation> Get()
        {
            var list = new List<Relation>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = dbContext.relations.AsEnumerable().Select(i => new Relation(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public IEnumerable<Relation> GetActive()
        {
            var list = new List<Relation>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = dbContext.relations.Where(i=>i.IsActive==true).AsEnumerable().Select(i => new Relation(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public Relation Get(int Id)
        {

            try
            {
                using (var dbContext = new SMSEntities())
                {
                    return new Relation(dbContext.relations.Where(i => i.Id == Id).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public Relation Post(Relation relation)
        {
            var item = relation.GetDataObject();
            using (var dbContext = new SMSEntities())
            {
                if (item.Id == 0)
                {
                    if (!IsAlreadyExist(item.Name))
                    {
                        dbContext.relations.Add(item);
                        dbContext.SaveChanges();
                    }
                }
                else
                {
                    dbContext.Entry(item).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            relation.Id = item.Id;
            return relation;
        }
        private bool IsAlreadyExist(string name)
        {
            bool result = false;
            using (var dbContext = new SMSEntities())
            {
                var item = dbContext.relations.Where(i => i.Name.ToLower() == name.ToLower()).FirstOrDefault();
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
                var item = dbContext.relations.Where(i => i.Id == Id).FirstOrDefault();
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