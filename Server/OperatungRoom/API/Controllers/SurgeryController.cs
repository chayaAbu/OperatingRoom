using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SurgeryController : ApiController
    {

        OpreatingRoomEntities1 db = new OpreatingRoomEntities1();
        // get surgery from current date
        [Route("api/Surgery/GetSurgeryFromCurrentDate")]
        public List<SurgeryDTO> GetSurgeryFromCurrentDate()
        {
            List<SurgeryDTO> s = BL.SurgeryManager.GetSurgeryFromCurrentDate();
            return s;
        }

        // get surgery from specific date
        [Route("api/Surgery/GetSurgeryFromSpecificDate")]
        public List<SurgeryDTO> GetSurgeryFromSpecificDate(DateTime specificDate)
        {
            List<SurgeryDTO> s = BL.SurgeryManager.GetSurgeryFromSpecificDate(specificDate);
            return s;
        }

        // get all surgery
        [Route("api/Surgery/GetAllSurgery")]
        public List<SurgeryDTO> GetAllSurgery()
        {
            List<SurgeryDTO> s = BL.SurgeryManager.GetAllSurgery();
            return s;
        }

        // get sched surgery
        [Route("api/Surgery/GetSchedSurgery")]
        public List<SurgeryDTO> GetSchedSurgery()
        {
            List<SurgeryDTO> s = BL.SurgeryManager.GetSchedSurgery();
            return s;
        }

        // add surgery to table

        [Route("api/Surgery/AddSurgery")]
        [HttpPost]
        public SurgeryDTO AddSurgery(SurgeryDTO newSurgery)
        {
            SurgeryDTO s = BL.SurgeryManager.AddNewSurgery(newSurgery);
            return s;
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
