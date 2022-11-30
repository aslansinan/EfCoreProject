using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTutorial.Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Number { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual StudentAdress Adress { get; set; }
    }
}
