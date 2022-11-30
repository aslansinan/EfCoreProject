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
        public int AddressId { get; set; } //birebir ilişki
        public virtual StudentAdress Adress { get; set; } //bire çok ilişki

        public ICollection<Book> Books { get; set; } // bire-çok
        public virtual ICollection<Course> Courses { get; set; } // çoka-çok
    }
}
