using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCT.API.Data;

namespace WCT.API.Models
{
    public class Day
    {
        public Day()
        {


        }
        public Day(day day)
        {
            if (day != null)
            {
                this.Id = day.Id;
                this.Name = day.Name;
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public day GetDataObject()
        {
            var dataObject = new day()
            {
                Id = this.Id,
                Name = this.Name
            };
            return dataObject;
        }
    }
}