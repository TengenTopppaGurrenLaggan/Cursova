﻿
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaHr.Models
{
    public class VacViewModel
    {

        public int Id { get; set; }
        [Required]
        public int Salary { get; set; }

        [Required]
        public string Vacname { get; set; }
        [Required]
        public int Category_Id { get; set; }
        public Category Category { get; set; }
        [Required]
        public int Cust_Id { get; set; }
        public Cust Cust { get; set; }


        

    }
}
