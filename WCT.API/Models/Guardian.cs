using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCT.API.Data;

namespace WCT.API.Models
{
    public class Guardian
    {
        public Guardian()
        {

        }
        public Guardian(guardian guardian)
        {
            if (guardian != null)
            {
                this.Id = guardian.Id;
                this.Name = guardian.Name;
                this.Phone = guardian.Phone;
                this.Occupation = guardian.Occupation;
                this.Address = guardian.Address;
                this.Relation = new Relation(guardian.relation);

            }
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
        public int RelationId { get; set; }
        public Relation Relation { get; set; }

        public guardian GetDataObject()
        {
            var dataObject = new guardian()
            {
                Id = this.Id,
                Name = this.Name,
                Phone = this.Phone,
                Occupation = this.Occupation,
                Address = this.Address,
                RelationId=this.RelationId
            };
            return dataObject;
        }
    }
}