using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCT.API.Data;

namespace WCT.API.Models
{
    public class Class
    {
        public Class()
        {

        }
        public Class(@class cls)
        {
            if (cls != null)
            {
                this.Id = cls.Id;
                this.Name = cls.Name;
                this.IsActive = cls.IsActive;
                this.Sections = cls.classsections.Select(i => new Section(i.section)).ToList();
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<Section> Sections { get; set; }
        public @class GetDataObject()
        {
            var dataObject = new @class()
            {
                Id = this.Id,
                Name = this.Name,
                IsActive = this.IsActive
            };
            return dataObject;
        }
    }
}