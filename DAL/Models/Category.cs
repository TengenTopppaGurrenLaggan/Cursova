namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        public int Id { get; set; }

        public string Catname { get; set; }
        
        public ICollection<Resume> Resume { get; set; }
        public ICollection<Vac> Vac { get; set; }
        public Category()
        {
            Resume = new HashSet<Resume>();
            Vac = new HashSet<Vac>();
        }

    }
}
