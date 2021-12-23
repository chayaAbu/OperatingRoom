using API.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    
    public class SurgeryController : ApiController
    {
        OperatingRoomEntities db = new OperatingRoomEntities();
        // get surgery from current date
        [Route("api/Shop/GetProductByCost/{price}")]
        public List<SurgeryDTO> GetSurgeryFromCurrentDate()
        {
            return SurgeryDTO.CreateSurgeryDtoList(db.surgery.Where(S => S.surgeryDate == DateTime.Now).ToList());
        }

        // GET: api/Surgery/5
        public string Get(int id)
        {
            return "value";
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
