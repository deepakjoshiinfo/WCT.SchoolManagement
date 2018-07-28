using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WCT.API.Models;
using WCT.API.Repository;

namespace WCT.API.Controllers
{
    public class ClassTimetableController : BaseController
    {
        ClassTimetableRepo ClassTimetableRepo;
        public ClassTimetableController()
        {
            ClassTimetableRepo = new ClassTimetableRepo();
        }
        public IHttpActionResult Get()
        {
            var list = ClassTimetableRepo.Get();
            if (list != null && list.Count() > 0)
            {
                return Ok(list);
            }
            return NotFound();
        }
        public IHttpActionResult GetActive()
        {
            var list = ClassTimetableRepo.GetActive();
            if (list != null && list.Count() > 0)
            {
                return Ok(list);
            }
            return NotFound();
        }
        public IHttpActionResult Get(int Id)
        {
            var item = ClassTimetableRepo.Get(Id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }
        public IHttpActionResult Post(ClassTimetable classTimetable)
        {
            var item = ClassTimetableRepo.Post(classTimetable);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }
        public IHttpActionResult Delete(int Id)
        {
            var result = ClassTimetableRepo.Delete(Id);
            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult GetDays()
        {
            var list = ClassTimetableRepo.GetDays();
            if (list != null && list.Count() > 0)
            {
                return Ok(list);
            }
            return NotFound();
        }
        [HttpGet]
        public IHttpActionResult GetTimetable(int classId, int sectionId, int subjectId)
        {
            var list = ClassTimetableRepo.GetTimetable(classId,sectionId,subjectId);
            if (list != null && list.Count() > 0)
            {
                return Ok(list);
            }
            return NotFound();
        }
        [HttpGet]
        public IHttpActionResult GetTimetableDetails(int classId, int sectionId)
        {
            var list = ClassTimetableRepo.GetTimetableDetails(classId, sectionId);
            if (list != null )
            {
                return Ok(list);
            }
            return NotFound();
        }
    }
}