using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class ClassDTO
    {
        public int idClass { get; set; }
        public string className { get; set; }

        public ClassDTO()
        {

        }

        public ClassDTO(classes c)
        {
            this.idClass = c.idClass;
            this.className = c.className;
        }
        public static List<ClassDTO> CreateClassDtoList(List<classes> classesList)
        {
            List<ClassDTO> dtoClassList = new List<ClassDTO>();
            foreach (var c in classesList)
            {
                ClassDTO dtoClass = new ClassDTO(c);
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
