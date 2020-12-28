using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaHr.Models
{
    public class CategoryViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Category Name")]
        [MaxLength(20)]
        public string Catname { get; set; }

       public List<Resume> Resume { get; set; }

        public List<Vac> Vac { get; set; }

    }
}
