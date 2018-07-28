using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WCT.API.Data;
using WCT.API.Models;

namespace WCT.API.Repository
{
    public class ClassTimetableRepo
    {
        public IEnumerable<ClassTimetable> Get()
        {
            var list = new List<ClassTimetable>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = dbContext.timetables.AsEnumerable().Select(i => new ClassTimetable(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public IEnumerable<ClassTimetable> GetActive()
        {
            var list = new List<ClassTimetable>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = dbContext.timetables.Where(i => i.IsActive == true).AsEnumerable().Select(i => new ClassTimetable(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public ClassTimetable Get(int Id)
        {

            try
            {
                using (var dbContext = new SMSEntities())
                {
                    return new ClassTimetable(dbContext.timetables.Where(i => i.Id == Id).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ClassTimetable Post(ClassTimetable timetable)
        {
            var item = timetable.GetDataObject();
            using (var dbContext = new SMSEntities())
            {
                if (item.Id == 0)
                {
                        dbContext.timetables.Add(item);
                        dbContext.SaveChanges();
                   
                }
                else
                {
                    dbContext.Entry(item).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            timetable.Id = item.Id;
            return timetable;
        }
        
        public bool Delete(int Id)
        {
            bool result = false;
            using (var dbContext = new SMSEntities())
            {
                var item = dbContext.timetables.Where(i => i.Id == Id).FirstOrDefault();
                if (item != null)
                {
                    item.IsActive = false;
                }
                dbContext.Entry(item).State = EntityState.Modified;
                dbContext.SaveChanges();
                result = true;
            }
            return result;
        }
        public IEnumerable<Day> GetDays()
        {
            var list = new List<Day>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = dbContext.days.AsEnumerable().Select(i => new Day(i)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public IEnumerable<AddTimetable> GetTimetable(int classId, int sectionId, int subjectId)
        {
            var list = new List<AddTimetable>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = (from d in dbContext.days
                            join t in dbContext.timetables on d.Id equals t.DayId into tt
                            from t in tt.DefaultIfEmpty()
                            select new AddTimetable() { Id = t.Id, IsActive = (t == null ? true : t.IsActive), ClassId = classId, DayId = d.Id, DayName = d.Name, EndTime = t.EndTime, StartTime = t.StartTime, RoomNo = t.RoomNo, SectionId = sectionId, SubjectId = subjectId }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        //public IEnumerable<ShowTimetable> GetTimetableDetails(int classId, int sectionId)
        //{
        //    var list = new List<ShowTimetable>();
        //    try
        //    {
        //        using (var dbContext = new SMSEntities())
        //        {
        //            list = (from t in dbContext.timetables.Where(i => (i.ClassId == classId && i.SectionId == sectionId))
        //                    join d in dbContext.days on t.DayId equals d.Id into dd
        //                    from d in dd.DefaultIfEmpty()
        //                    join s in dbContext.subjects on t.SubjectId equals s.Id into ss
        //                    from s in ss.DefaultIfEmpty()
        //                    select new ShowTimetable() { Id = t.Id, IsActive = (t == null ? true : t.IsActive), ClassId = classId, DayId = d.Id, DayName = d.Name, EndTime = t.EndTime, StartTime = t.StartTime, RoomNo = t.RoomNo, SectionId = sectionId, SubjectName = s.Name }).OrderBy(i=>i.DayId).ToList();


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return list;
        //}
        public object GetTimetableDetails(int classId, int sectionId)
        {
            object list;//= new List<DisplayTimetable>();
            try
            {
                using (var dbContext = new SMSEntities())
                {
                    list = (from c in (from t in dbContext.timetables.Where(i => (i.ClassId == classId && i.SectionId == sectionId && i.StartTime!=null))
                                       join d in dbContext.days on t.DayId equals d.Id into dd
                                       from d in dd.DefaultIfEmpty()
                                       join s in dbContext.subjects on t.SubjectId equals s.Id into ss
                                       from s in ss.DefaultIfEmpty()
                                       select new DisplayTimetable()
                                       {
                                           Id = t.SubjectId,
                                           Monday = (t.StartTime != null && t.DayId == 1) ? (t.StartTime + "-" + t.EndTime) : "N/A",
                                           Tuesday = (t.StartTime != null && t.DayId == 2) ? (t.StartTime + "-" + t.EndTime) : "N/A",
                                           Wednesday = (t.StartTime != null && t.DayId == 3) ? (t.StartTime + "-" + t.EndTime) : "N/A",
                                           Thursday = (t.StartTime != null && t.DayId == 4) ? (t.StartTime + "-" + t.EndTime) : "N/A",
                                           Friday = (t.StartTime != null && t.DayId == 5) ? (t.StartTime + "-" + t.EndTime) : "N/A",
                                           Saturday = (t.StartTime != null && t.DayId == 6) ? (t.StartTime + "-" + t.EndTime) : "N/A",
                                           SubjectName = s.Name
                                       })
                            group c by new
                            {
                                c.SubjectName,
                                c.Monday,
                                c.Tuesday,
                                c.Wednesday,
                                c.Thursday,
                                c.Friday,
                                c.Saturday
                            } into gcs
                            select new
                            {
                                Subject = gcs.Key.SubjectName,
                                Monday = gcs.Key.Monday,
                                Tuesday = gcs.Key.Tuesday,
                                Wednesday = gcs.Key.Wednesday,
                                Thursday = gcs.Key.Thursday,
                                Friday = gcs.Key.Friday,
                                Saturday = gcs.Key.Saturday
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
    }
}