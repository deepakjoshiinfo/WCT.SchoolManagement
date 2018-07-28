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
    public class GenderController : BaseController
    {
        GenderRepo genderRepo;
        public GenderController()
        {
            genderRepo = new GenderRepo();
        }
        public IHttpActionResult Get()
        {
            var list = genderRepo.Get();
            if (list != null && list.Count() > 0)
            {
                return Ok(list);
            }
            return NotFound();
        }
        public IHttpActionResult GetActive()
        {
            var list = genderRepo.GetActive();
            if (list != null && list.Count() > 0)
            {
                return Ok(list);
            }
            return NotFound();
        }
        public IHttpActionResult Get(int Id)
        {
            var item = genderRepo.Get(Id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }
        public IHttpActionResult Post(Gender gender)
        {
            var item = genderRepo.Post(gender);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }
        public IHttpActionResult Delete(int Id)
        {
            var result = genderRepo.Delete(Id);
            return Ok(result);
        }
    }
}
