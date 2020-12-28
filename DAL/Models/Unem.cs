namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Unem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
        [Required]
        public int Age { get; set; }
        public ICollection<Resume> Resume { get; set; }
        
        public Unem()
        {
            Resume = new HashSet<Resume>();
            
        }
    }
}
