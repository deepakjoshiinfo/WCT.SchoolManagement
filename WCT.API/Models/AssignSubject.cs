using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCT.API.Data;

namespace WCT.API.Models
{
    public class AssignSubject
    {
        public AssignSubject()
        {

        }
        public AssignSubject(assignsubject assignsubject)
        {
            this.Id = assignsubject.Id;
            this.ClassId = assignsubject.ClassId;
            this.SubjectId = assignsubject.SubjectId;
            this.SectionId = assignsubject.SectionId;
            this.TeacherId = assignsubject.TeacherId;
            this.IsActive = assignsubject.IsActive;

        }
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int SectionId  { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public bool IsActive { get; set; }
        public assignsubject GetDataObject()
        {
            var dataObject = new assignsubject()
            {
                Id = this.Id,
                ClassId = this.ClassId,
                SubjectId = this.SubjectId,
                SectionId = this.SectionId,
                TeacherId = this.TeacherId,
                IsActive = this.IsActive
            };
            return dataObject;
        }
    }
};