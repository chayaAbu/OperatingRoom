﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
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
        public static List<SurgeryDTO> GetSurgeryFromSpecificDate(DateTime specificDate)
        {
            List<surgery> surgeriesFromTable = db.GetDbSet<surgery>().Where(S => S.surgeryDate == specificDate).ToList();
            List<SurgeryDTO> CreateSurgeryDtoList = SurgeryDTO.CreateSurgeryDtoList(surgeriesFromTable);
            return CreateSurgeryDtoList;

        }
        public static List<SurgeryDTO> GetSurgeryToDelate()
        {
            List<surgery> surgeriesFromTable = db.GetDbSet<surgery>().Where(S => S.surgeryDate < DateTime.Today).ToList();
            List<SurgeryDTO> CreateSurgeryDtoList = SurgeryDTO.CreateSurgeryDtoList(surgeriesFromTable);
            foreach(var del in CreateSurgeryDtoList)
            {
                DelateSurgery(del);
            }
            return CreateSurgeryDtoList;

        }
        public static List<SurgeryDTO> GetAllSurgery()
        {
            List<surgery> surgeriesFromTable = db.GetDbSet<surgery>().ToList();
            List<SurgeryDTO> CreateSurgeryDtoList = SurgeryDTO.CreateSurgeryDtoList(surgeriesFromTable);
            return CreateSurgeryDtoList;

        }
        public static List<SurgeryDTO> GetSchedSurgery()
        {
            List<surgery> surgeriesFromTable = db.GetDbSet<surgery>().Where(S => S.hasSches == false).ToList();
            List<SurgeryDTO> CreateSurgeryDtoList = SurgeryDTO.CreateSurgeryDtoList(surgeriesFromTable);
            return CreateSurgeryDtoList;

        }
        public static SurgeryDTO AddNewSurgery(SurgeryDTO AddSurgery)
        {
            surgery newSurgery = AddSurgery.SurgeryToTable();
            db.Execute<surgery>(newSurgery, DBConection.ExecuteActions.Insert);
            AddSurgery.surgeryCode = newSurgery.surgeryCode;
            return AddSurgery;

        }
        public static SurgeryDTO UpdateSurgery(SurgeryDTO UpSurgery)
        {
            surgery updSurgery = UpSurgery.SurgeryToTable();
            db.Execute<surgery>(updSurgery, DBConection.ExecuteActions.Update);
            UpSurgery.surgeryCode = updSurgery.surgeryCode;
            return UpSurgery;

        }
        public static SurgeryDTO DelateSurgery(SurgeryDTO DelSurgery)
        {
            List<DeviceForSurgeryDTO> FreeDevice = DeviceForSurgeryManager.GetAllSpecialDeviceAccordingCode(DelSurgery.surgeryCode);
            foreach (var D in FreeDevice)
            {
                SpecialDeviceDTO toChange = SpecialDeviceManager.GetAllSpecialDeviceAccordingName(D.deviceName);
                if (toChange.isAvailable == true)
                    toChange.isAvailable = false;
                toChange.amount += D.amount;
                SpecialDeviceManager.UpdateDevice(toChange);
                DeviceForSurgeryManager.DelateDeviceRequest(D);


            }
            SchedulingDTO s = SchedulingManager.GetAccordingSched(DelSurgery.surgeryCode);
            SchedulingManager.DeleteScheduling(s);
            surgery delSurgery = DelSurgery.SurgeryToTable();
            db.Execute<surgery>(delSurgery, DBConection.ExecuteActions.Delete);
            return DelSurgery;

        }
        public static SurgeryDTO GetSurgeryAccordingCode(int code)
        {
            surgery surgeriesFromTable = db.GetDbSet<surgery>().Where(S => S.surgeryCode == code).Single();
            SurgeryDTO CreateSurgeryDtoList = new SurgeryDTO(surgeriesFromTable);
            return CreateSurgeryDtoList;



        }

    }
}
