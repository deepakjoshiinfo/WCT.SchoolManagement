using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCT.API.Data;

namespace WCT.API.Models
{
    public class ClassTimetable
    {
        public ClassTimetable()
        {

        }
        public ClassTimetable(timetable timetable)
        {
            if (timetable != null)
            {
                this.Id = timetable.Id;
                this.SubjectId = timetable.SubjectId;
                this.ClassId = timetable.ClassId;
                this.SectionId = timetable.SectionId;
                this.IsActive = timetable.IsActive;
                this.DayId = timetable.DayId;
                this.StartTime = timetable.StartTime;
                this.EndTime = timetable.EndTime;
                this.RoomNo = timetable.RoomNo;
            }
        }
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public bool IsActive { get; set; }
        public int DayId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string RoomNo { get; set; }
        public timetable GetDataObject()
        {
            var dataObject = new timetable()
            {
                Id = this.Id,
                SubjectId = this.SubjectId,
                ClassId = this.ClassId,
                SectionId = this.SectionId,
                IsActive = this.IsActive,
                DayId = this.DayId,
                StartTime = this.StartTime,
                EndTime = this.EndTime,
                RoomNo = this.RoomNo

            };
            return dataObject;
        }
    }
}