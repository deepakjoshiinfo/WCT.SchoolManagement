using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCT.API.Data;

namespace WCT.API.Models
{
    public class Teacher
    {
        public Teacher()
        {

        }
        public Teacher(teacher teacher)
        {
            if (teacher != null)
            {
                this.Id = teacher.Id;
                this.Name = teacher.Name;
                this.Email = teacher.Email;
                this.Gender = new Gender(teacher.gender);
                this.GenderId = teacher.GenderId.HasValue ? teacher.GenderId.Value : 0;
                this.DOB = teacher.DOB;
                this.Address = teacher.Address;
                this.Phone = teacher.Phone;
                this.IsActive = teacher.IsActive;
                this.TeminationDate = teacher.TeminationDate;
                this.CreatedBy = teacher.CreatedBy;
                this.CreatedDate = teacher.CreatedDate;
                this.ModifiedBy = teacher.ModifiedBy;
                this.ModifiedDate = teacher.ModifiedDate;
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int GenderId { get; set; }
        
        public Gender Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime? TeminationDate { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public teacher GetDataObject()
        {
            var dataObject = new teacher()
            {
                Id = this.Id,
                Name = this.Name,
                Email = this.Email,
                GenderId = this.GenderId,
                DOB = this.DOB,
                Address = this.Address,
                Phone = this.Phone,
                IsActive = this.IsActive,
                TeminationDate = this.TeminationDate,
                CreatedBy = this.CreatedBy,
                CreatedDate = this.CreatedDate,
                ModifiedBy = this.ModifiedBy,
                ModifiedDate = this.ModifiedDate
            };
            return dataObject;
        }
    }
}