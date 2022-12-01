using EfCoreTutorial.Data.Context;
using EfCoreTutorial.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTutorial.WebApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StudentController(ApplicationDbContext applicationDbContext )
        {
            this.applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students =  applicationDbContext.Students.ToListAsync();//Filtreleme yaparken en sonda tolist ve  ToListAsync gibi avg,sum,sonda kullanmak daha doğru bir yapıdır.
            return Ok(students);
        }
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            //StudentAdress address = new StudentAdress(){
            //    City = "iSTANBUL",
            //    Country="Turkey",
            //    District ="Tuzla",
            //    FullAdress ="aYDINLI kOKNAR, no=7"
            //};
            //applicationDbContext.studentAdresses.AddAsync(address);
            //await applicationDbContext.SaveChangesAsync();

            Student st = new Student() // burayı normalde repository içerisinde yapıyoruz.
            {
                FirstName = "Sinan",
                LastName = "Aslan",
                Number = 1,
                Adress = new StudentAdress()
                {
                    City = "iSTANBUL",
                    Country = "Turkey",
                    District = "Tuzla",
                    FullAdress = "aYDINLI kOKNAR, no=7"
                }
            };
            applicationDbContext.Students.AddAsync(st);
            await applicationDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await applicationDbContext.Students.FirstOrDefaultAsync(i => i.Id == id);
            //var student = await applicationDbContext.Students.FirstAsync(id);
            applicationDbContext.Students.Remove(student);
            await applicationDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update()
        {
            var student = await applicationDbContext.Students.FirstOrDefaultAsync();
            student.FirstName = "Tuğba";
            student.LastName = "ANDAK";
            await applicationDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
