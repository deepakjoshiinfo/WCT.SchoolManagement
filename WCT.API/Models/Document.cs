using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCT.API.Data;

namespace WCT.API.Models
{
    public class Document
    {
        public Document()
        {

        }
        public Document(document document)
        {
            if (document != null)
            {
                this.Id = document.Id;
                this.Name = document.Name;
                this.StudentId = document.StudentId;
                this.ImageURL = document.ImageURL;
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentId { get; set; }
        public string ImageURL { get; set; }
        
        public document GetDataObject()
        {
            var dataObject = new document()
            {
                Id = this.Id,
                Name = this.Name,
                StudentId = this.StudentId,
                ImageURL = this.ImageURL
            };
            return dataObject;
        }
    }
}