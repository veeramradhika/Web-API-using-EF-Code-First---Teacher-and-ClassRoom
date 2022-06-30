using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEFDBProject.Entites
{
    public class Teachers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [System.ComponentModel.DataAnnotations.Key]

        public int ID { get; set; }

        [Column(TypeName = "Varchar(50)")]

        public string? Name { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string? Address { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string? EmailId { get; set; }



        public ICollection<ClassRoom>? ClassRoomList { get; set; }
    }
}
