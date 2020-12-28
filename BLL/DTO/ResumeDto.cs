
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ResumeDto
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Workexp ")]

        public int Worktime { get; set; }
        [Required]
        public int Unem_Id { get; set; }
        //public Category Category { get; set; }
        public int Category_Id { get; set; }
      // public Unem Unem { get; set; }
        [Required]
        public string Resname { get; set; }



    }
}
