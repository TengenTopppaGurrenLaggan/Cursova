using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UnemDto
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Enter name Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Surname Name")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Enter age ")]
        public int Age { get; set; }
        public List<Vac> Vac { get; set; }

    }
}
