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
    public class SectionController : BaseController
    {
        SectionRepo sectionRepo;
        public SectionController()
        {
            sectionRepo = new SectionRepo();
        }
        public IHttpActionResult Get()
        {
            var list = sectionRepo.Get();
            if (list != null && list.Count() > 0)
            {
                return Ok(list);
            }
            return NotFound();
        }
        public IHttpActionResult GetActive()
        {
            var list = sectionRepo.GetActive();
            if (list != null && list.Count() > 0)
            {
                return Ok(list);
            }
            return NotFound();
        }
        public IHttpActionResult Get(int Id)
        {
            var item = sectionRepo.Get(Id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }
        public IHttpActionResult Post(Section section)
        {
            var item = sectionRepo.Post(section);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }
        public IHttpActionResult Delete(int Id)
        {
            var result = sectionRepo.Delete(Id);
            return Ok(result);
        }
    }
}
