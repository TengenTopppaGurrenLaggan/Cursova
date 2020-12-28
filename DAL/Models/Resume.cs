namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Resume
    {
        public int Id { get; set; }
        [Required]
        public int Worktime { get; set; }
        [Required]
        public int Unem_Id { get; set; }
        //public Unem Unem { get; set; }
     [Required]
        public int Category_Id { get; set; }
        [Required]
        public string Resname { get; set; }
        //public Category Category { get; set; }
        
        //public Resume()
        //{
        //    Unem = new HashSet<Unem>();
        //    Category = new HashSet<Category>();
        //}
    }
}
