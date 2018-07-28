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
    public class AssignSubjectController : BaseController
    {
        AssignSubjectRepo assignSubjectRepo;
        public AssignSubjectController()
        {
            assignSubjectRepo = new AssignSubjectRepo();
        }
        public IHttpActionResult Get()
        {
            var list = assignSubjectRepo.Get();
            if (list != null && list.Count() > 0)
            {
                return Ok(list);
            }
            return NotFound();
        }
        public IHttpActionResult GetActive()
        {
            var list = assignSubjectRepo.GetActive();
            if (list != null && list.Count() > 0)
            {
                return Ok(list);
            }
            return NotFound();
        }
        public IHttpActionResult Get(int Id)
        {
            var item = assignSubjectRepo.Get(Id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }
        public IHttpActionResult Post(AssignSubject assignSubject)
        {
            var item = assignSubjectRepo.Post(assignSubject);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }
        public IHttpActionResult Delete(int Id)
        {
            var result = assignSubjectRepo.Delete(Id);
            return Ok(result);
        }
        [HttpGet]
        public IHttpActionResult SearchTeachers(int classId, int sectionId)
        {
            var list = assignSubjectRepo.SearchTeachers(classId,sectionId);
            if (list != null && list.Count() > 0)
            {
                return Ok(list);
            }
            return NotFound();
        }
    }
}
