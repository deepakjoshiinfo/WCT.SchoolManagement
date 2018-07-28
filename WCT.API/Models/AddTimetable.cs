using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCT.API.Data;

namespace WCT.API.Models
{
    public class AddTimetable
    {
       
        public int? Id { get; set; }
        public int SubjectId { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public bool IsActive { get; set; }
        public int DayId { get; set; }
        public string DayName { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string RoomNo { get; set; }
       
    }
}