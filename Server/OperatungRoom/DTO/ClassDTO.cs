using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class ClassesDTO
    {
        public int idClass { get; set; }
        public string className { get; set; }

        public ClassesDTO()
        {

        }

        public ClassesDTO(classes c)
        {
            this.idClass = c.idClass;
            this.className = c.className;
        }
        public static List<ClassesDTO> CreateClassDtoList(List<classes> classesList)
        {
            List<ClassesDTO> dtoClassList = new List<ClassesDTO>();
            foreach (var c in classesList)
            {
                ClassesDTO dtoClass = new ClassesDTO(c);
                dtoClassList.Add(dtoClass);
            }
            return dtoClassList;
        }
        public classes SurgeryToTable()
        {
            classes c = new classes();
            c.idClass = idClass;
            c.className = className;
            return c;
        }
    }
}
