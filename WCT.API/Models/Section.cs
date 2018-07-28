using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCT.API.Data;

namespace WCT.API.Models
{
    public class Section
    {
        public Section()
        {

        }
        public Section(section section)
        {
            if (section != null)
            {
                this.Id = section.Id;
                this.Name = section.Name;
                this.IsActive = section.IsActive;
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsSelected { get; set; }
        public section GetDataObject()
        {
            var dataObject = new section()
            {
                Id = this.Id,
                Name = this.Name,
                IsActive = this.IsActive
            };
            return dataObject;
        }
    }
}