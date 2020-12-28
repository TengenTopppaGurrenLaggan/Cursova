namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vac
    {
        public int Id { get; set; }
        [Required]
        public int Salary { get; set; }

        [Required]
        public string Vacname { get; set; }
       [Required]
        public int Category_Id { get; set; }
        [Required]
        public int Cust_Id { get; set; }
        public virtual Category Category { get; set; }
        public virtual Cust Cust { get; set; }
        
        //public Vac()
        //{
        //    Cust = new HashSet<Cust>();
        //    Category = new HashSet<Category>();
        //}
    }
}
