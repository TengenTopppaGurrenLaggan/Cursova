namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cust
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
        [Required]
        public int Age { get; set; }
        
        public ICollection<Vac> Vac { get; set; }
        public Cust()
        {
            Vac = new HashSet<Vac>();
        }
    }
}
