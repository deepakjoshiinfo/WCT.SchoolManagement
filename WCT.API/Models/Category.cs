using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCT.API.Data;

namespace WCT.API.Models
{
    public class Category
    {
        public Category()
        {


        }
        public Category(category category)
        {
            if (category != null)
            {
                this.Id = category.Id;
                this.Name = category.Name;
                this.IsActive = category.IsActive;
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public category GetDataObject()
        {
            var dataObject = new category()
            {
                Id = this.Id,
                Name = this.Name,
                IsActive = this.IsActive
            };
            return dataObject;
        }
    }
}