using BL;
using DTO;
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
    public class SchedulingController : ApiController
    {

        // GET: api/Scheduling
        [Route("api/Scheduling/GetSchedulng")]
        [HttpGet]
        public List<SchedulingDTO> GetSchedulng()
        {
            SurgeryManager.GetSurgeryToDelate();
           HungrienScudling.FillMatrix();
            return BL.SchedulingManager.GetAllSched();
        }

        // add to scheduling table
        [Route("api/Scheduling/AddSched")]
        [HttpPost]
        public SchedulingDTO AddSched(SchedulingDTO sched)
        {
            SchedulingDTO s = BL.SchedulingManager.AddScheduling(sched);
            return s;
        }

        // POST: get the last scheduling
        public SchedulingDTO GetLast(int ToSched)
        {
            SchedulingDTO s = BL.SchedulingManager.GetLast(ToSched);
            return s;
        }

        // emergency case
        [Route("api/Scheduling/EmergencyCase")]
        [HttpPost]
        public void EmergencyCase(SurgeryDTO surg)
        {
            BL.SchedulingManager.EmergencyCase();
            SurgeryManager.AddNewSurgery(surg);
            GetSchedulng();
            
        }
        // DELETE: api/Scheduling/5
        public void Delete(int id)
        {
        }
    }
}
