﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.DTO;
using DAL;


namespace BL
{


    public class SurgeryManager
    {
        static DBConection db = new DBConection();
        public static List<SurgeryDTO> GetSurgeryFromCurrentDate()
        {
            List<surgery> surgeriesFromTable = db.GetDbSet<surgery>().Where(S => S.surgeryDate == DateTime.Today).ToList();
            List<SurgeryDTO> CreateSurgeryDtoList = SurgeryDTO.CreateSurgeryDtoList(surgeriesFromTable);
            return CreateSurgeryDtoList;

        }
    }
}
