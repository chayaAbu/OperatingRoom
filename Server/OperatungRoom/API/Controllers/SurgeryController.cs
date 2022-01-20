using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.DTO;

namespace API.Controllers
{
    
    public class SurgeryController : ApiController
    {
        OperatingRoomEntities db = new OperatingRoomEntities();
        // get surgery from current date
        [Route("api/Surgery/GetSurgeryFromCurrentDate")]
        public List<SurgeryDTO> GetSurgeryFromCurrentDate()
        {
            List<SurgeryDTO> s = BL.SurgeryManager.GetSurgeryFromCurrentDate();
            return s;
        }

        // add surgery to table

        [Route("api/Surgery/SurgeryToTable")]
        [HttpPost]
        public string SurgeryToTable(SurgeryDTO newSurgery)
        {
            surgery s = newSurgery.SurgeryToTable();
            db.surgery.Add(s);
            db.SaveChanges();
            return "succes";
        }

        // POST: api/Surgery
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Surgery/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Surgery/5
        public void Delete(int id)
        {
        }
    }
}
