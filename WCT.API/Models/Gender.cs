using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCT.API.Data;

namespace WCT.API.Models
{
    public class Gender
    {
        public Gender()
        {

        }
        public Gender(gender gender)
        {
            if (gender != null)
            {
                this.Id = gender.Id;
                this.Name = gender.Name;
                this.IsActive = gender.IsActive;
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public gender GetDataObject()
        {
            var dataObject = new gender()
            {
                Id = this.Id,
                Name = this.Name,
                IsActive = this.IsActive
            };
            return dataObject;
        }
    }
}