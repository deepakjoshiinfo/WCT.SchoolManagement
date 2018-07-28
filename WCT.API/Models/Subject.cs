using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCT.API.Data;

namespace WCT.API.Models
{
    public class Subject
    {
        public Subject()
        {
           
        }
        public Subject(subject subject)
        {
            if (subject != null)
            {
                this.Id = subject.Id;
                this.Name = subject.Name;
                this.IsActive = subject.IsActive;
                this.SubjectTypeId = subject.SubjectTypeId;
                this.Code = subject.Code;
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public int SubjectTypeId { get; set; }

        public subject GetDataObject()
        {
            var dataObject = new subject()
            {
                Id = this.Id,
                Name = this.Name,
                IsActive = this.IsActive,
                SubjectTypeId=this.SubjectTypeId,
                Code=this.Code
            };
            return dataObject;
        }
    }
}