using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCT.API.Data;

namespace WCT.API.Models
{
    public class Student
    {
        public Student()
        {

        }
        public Student(student stu)
        {
            if (stu != null)
            {
                this.Id = stu.Id;
                this.AdmissionNumber = stu.AdmissionNumber;
                this.ClassId = stu.ClassId;
                this.SectionId = stu.SectionId;
                this.FirstName = stu.FirstName;
                this.LastName = stu.LastName;
                this.GenderId = stu.GenderId;
                this.Gender = new Gender(stu.gender);
                this.DOB = stu.DOB;
                this.CategoryId = stu.CategoryId;
                this.Category = new Category(stu.category);
                this.Religion = stu.Religion;
                this.Cast = stu.Cast;
                this.MobileNumber = stu.MobileNumber;
                this.Email = stu.Email;
                this.RTE = stu.RTE;
                this.FatherId = stu.FatherId;
                this.Father = new Guardian(stu.guardian1);
                this.MotherId = stu.MotherId;
                this.Mother = new Guardian(stu.guardian);
                this.GuardianId = stu.GuardianId;
                this.Guardian = new Guardian(stu.guardian2);
                this.IsGuardianAddressCurrent = stu.IsGuardianAddressCurrent != null ? stu.IsGuardianAddressCurrent.Value : false;
                this.IsPermanentAddressCurrent = stu.IsPermanentAddressCurrent != null ? stu.IsPermanentAddressCurrent.Value : false;
                this.CurrentAddress = stu.AdmissionNumber;
                this.PermanentAddress = stu.PermanentAddress;
                this.PreviousDetails = stu.PreviousDetails;
                this.IsActive = stu.IsActive;
                this.TeminationDate = stu.TeminationDate;
                this.Documents = stu.documents.Select(i => new Document(i)).ToList();
                this.CreatedBy = stu.CreatedBy;
                this.CreatedDate = stu.CreatedDate;
                this.ModifiedBy = stu.ModifiedBy;
                this.ModifiedDate = stu.ModifiedDate;
                this.Class = new Class(stu.@class);
                this.RollNumber = stu.RollNumber;
            }
        }
        public int Id { get; set; }
        public string AdmissionNumber { get; set; }
        public int ClassId { get; set; }
        public Nullable<int> SectionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public string Religion { get; set; }
        public string Cast { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public bool RTE { get; set; }
        public long? FatherId { get; set; }
        public Guardian Father
        {
            get;
            set;
        }
        public long? MotherId { get; set; }
        public Guardian Mother
        {
            get;
            set;
        }
        public long? GuardianId { get; set; }
        public Guardian Guardian
        {
            get;
            set;
        }
        public bool IsGuardianAddressCurrent { get; set; }
        public bool IsPermanentAddressCurrent { get; set; }

        public string CurrentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string PreviousDetails { get; set; }
        public bool IsActive { get; set; }
        public string RollNumber { get; set; }
        public Nullable<System.DateTime> TeminationDate { get; set; }

        public List<Document> Documents
        {
            get;
            set;
        }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public student GetDataObject()
        {
            var dataObject = new student()
            {
                AdmissionNumber = this.AdmissionNumber,
                RollNumber = this.RollNumber,
                Cast = this.Cast,
                CategoryId = this.CategoryId,
                ClassId = this.ClassId,
                CreatedBy = this.CreatedBy,
                CreatedDate = this.CreatedDate,
                CurrentAddress = this.CurrentAddress,
                DOB = this.DOB,
                Email = this.Email,
                FatherId = (this.Father != null) ? this.Father.Id : new Nullable<long>(),

                //FatherId = this.FatherId,
                FirstName = this.FirstName,
                //Gender = this.Gender,
                GenderId = this.GenderId,
                //GuardianId = this.GuardianId,
                GuardianId = (this.Guardian != null) ? this.Guardian.Id : new Nullable<long>(),

                Id = this.Id,
                IsActive = this.IsActive,
                LastName = this.LastName,
                MobileNumber = this.MobileNumber,
                ModifiedBy = this.ModifiedBy,
                ModifiedDate = this.ModifiedDate,
                //MotherId = this.MotherId,
                MotherId = (this.Mother != null) ? this.Mother.Id : new Nullable<long>(),

                PermanentAddress = this.PermanentAddress,
                PreviousDetails = this.PreviousDetails,
                Religion = this.Religion,
                RTE = this.RTE,

                SectionId = this.SectionId,
                TeminationDate = this.TeminationDate,
                documents = (this.Documents != null) ? this.Documents.Select(i => i.GetDataObject()).ToList() : new List<document>() // this.GetDataObject()
            };
            return dataObject;
        }
        public Class Class { get; set; }
        
    }
}