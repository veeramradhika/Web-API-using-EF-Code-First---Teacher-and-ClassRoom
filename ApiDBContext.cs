using ApiEFDBProject.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEFDBProject
{
    public class ApiDBContext:DbContext
    {
        public DbSet<Teachers> Teacher { set; get; }
        public DbSet<ClassRoom> ClassRooms { set; get; }
        public ApiDBContext()
        {

        }
        public ApiDBContext(DbContextOptions options)
       : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            OptionsBuilder.UseSqlServer(@"Data Source=RADHIKA;Initial Catalog=WebApiEF;Integrated Security=True");
        }

    }
}
