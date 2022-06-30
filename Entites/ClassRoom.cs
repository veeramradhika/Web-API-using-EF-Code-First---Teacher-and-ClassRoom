using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEFDBProject.Entites
{
    public class ClassRoom
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [System.ComponentModel.DataAnnotations.Key]

        public int ID { get; set; }

        [Column(TypeName = "Varchar(50)")]

        public string? ClassName { get; set; }



        public Teachers Teacher { get; set; }


    }
}
