using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DoctorDTO
    {
        public int idDoctor { get; set; }
        public string doctorName { get; set; }
        public int idClass { get; set; }
        public System.DateTime startHour { get; set; }
        public System.DateTime endHour { get; set; }

        public DoctorDTO()
        {

        }

        public DoctorDTO(doctor d)
        {
            this.idDoctor = d.idDoctor;
            this.doctorName = d.doctorName;
            this.idClass = d.idClass;
            this.startHour= d.startHour;
            this.endHour = d.endHour;

        }

        public static List<DoctorDTO> CreateDoctorDtoList(List<doctor> doctorList)
        {
            List<DoctorDTO> dtoDoctorList = new List<DoctorDTO>();
            foreach (var d in doctorList)
            {
                DoctorDTO dtoDoctor = new DoctorDTO(d);
                dtoDoctorList.Add(dtoDoctor);
            }
            return dtoDoctorList;
        }
        public doctor DoctorToTable()
        {
            doctor d = new doctor();
            d.idDoctor = idDoctor;
            d.doctorName = doctorName;
            d.idClass = idClass;
            d.startHour = startHour;
            d.endHour = endHour;
            return d;
        }
    }
}
