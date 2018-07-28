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
    public class TeacherController : BaseController
    {
        TeacherRepo teacherRepo;
        public TeacherController()
        {
            teacherRepo = new TeacherRepo();
        }
        public IHttpActionResult Get()
        {
            var list = teacherRepo.Get();
            if (list != null && list.Count() > 0)
            {
                return Ok(list);
            }
            return NotFound();
        }
        public IHttpActionResult GetActive()
        {
            var list = teacherRepo.GetActive();
            if (list != null && list.Count() > 0)
            {
                return Ok(list);
            }
            return NotFound();
        }
        public IHttpActionResult Get(int Id)
        {
            var item = teacherRepo.Get(Id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }
        public IHttpActionResult Post(Teacher teacher)
        {
            var item = teacherRepo.Post(teacher);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }
        public IHttpActionResult Delete(int Id)
        {
            var result = teacherRepo.Delete(Id);
            return Ok(result);
        }
    }
}
