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
    public class RelationController : BaseController
    {
        RelationRepo relationRepo;
        public RelationController()
        {
            relationRepo = new RelationRepo();
        }
        public IHttpActionResult Get()
        {
            var list = relationRepo.Get();
            if (list != null && list.Count() > 0)
            {
                return Ok(list);
            }
            return NotFound();
        }
        public IHttpActionResult GetActive()
        {
            var list = relationRepo.GetActive();
            if (list != null && list.Count() > 0)
            {
                return Ok(list);
            }
            return NotFound();
        }
        public IHttpActionResult Get(int Id)
        {
            var item = relationRepo.Get(Id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }
        public IHttpActionResult Post(Relation relation)
        {
            var item = relationRepo.Post(relation);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }
        public IHttpActionResult Delete(int Id)
        {
            var result = relationRepo.Delete(Id);
            return Ok(result);
        }
    }
}
