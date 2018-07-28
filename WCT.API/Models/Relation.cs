using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCT.API.Data;

namespace WCT.API.Models
{
    public class Relation
    {
        public Relation()
        {

        }
        public Relation(relation relation)
        {
            if (relation != null)
            {
                this.Id = relation.Id;
                this.Name = relation.Name;
                this.IsActive = relation.IsActive;
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public relation GetDataObject()
        {
            var dataObject = new relation()
            {
                Id = this.Id,
                Name = this.Name,
                IsActive = this.IsActive
            };
            return dataObject;
        }
    }
}