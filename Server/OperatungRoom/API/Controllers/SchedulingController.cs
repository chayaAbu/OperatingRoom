﻿using BL;
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

        // POST: api/Scheduling
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Scheduling/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Scheduling/5
        public void Delete(int id)
        {
        }
    }
}
