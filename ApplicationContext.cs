using Microsoft.EntityFrameworkCore;
using System.Numerics;
using TestovoeBack.Models;

namespace TestovoeBack
{
    public class ApplicationContext : DbContext
    {
        public DbSet<NoteDto> Notes { get; set; }
        public DbSet<HistoryDto> Histories { get; set; }
        public DbSet<EmployeeDto> Employees { get; set; }
        public DbSet<CompanyDto> Companies { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
            if (Companies?.Count() == 0)
            {

                CompanyDto company1 = new CompanyDto()
                {
                    Name = "SomeCompName1",
                    Adress = "SomeAdress",
                    City = "Somecity",
                    State = "SomeState",
                    Phone = "+123103103132"
                };
                CompanyDto company2 = new CompanyDto()
                {
                    Name = "SomeCompName2",
                    Adress = "SomeAdress",
                    City = "Somecity",
                    State = "SomeState",
                    Phone = "+123103103132"
                };
                Companies.AddRange
                 (
                     company1, company2
                 );
                Employees.AddRange
                 (
                      new EmployeeDto() { FirstName = "SomeFirst", LastName = "SomeLast", BirthDate = DateTime.Now, Position = "SomePos", Company = company1 },
                      new EmployeeDto() { FirstName = "SomeFirst1", LastName = "SomeLast", BirthDate = DateTime.Now, Position = "SomePos", Company = company1 },
                      new EmployeeDto() { FirstName = "SomeFirst2", LastName = "SomeLast", BirthDate = DateTime.Now, Position = "SomePos", Company = company1 },
                      new EmployeeDto() { FirstName = "SomeFirst3", LastName = "SomeLast", BirthDate = DateTime.Now, Position = "SomePos", Company = company1 },
                      new EmployeeDto() { FirstName = "SomeFirst4", LastName = "SomeLast", BirthDate = DateTime.Now, Position = "SomePos", Company = company1 },
                      new EmployeeDto() { FirstName = "SomeFirst5", LastName = "SomeLast", BirthDate = DateTime.Now, Position = "SomePos", Company = company2 },
                      new EmployeeDto() { FirstName = "SomeFirst6", LastName = "SomeLast", BirthDate = DateTime.Now, Position = "SomePos", Company = company2 },
                      new EmployeeDto() { FirstName = "SomeFirst7", LastName = "SomeLast", BirthDate = DateTime.Now, Position = "SomePos", Company = company2 },
                      new EmployeeDto() { FirstName = "SomeFirst8", LastName = "SomeLast", BirthDate = DateTime.Now, Position = "SomePos", Company = company2 },
                      new EmployeeDto() { FirstName = "SomeFirst9", LastName = "SomeLast", BirthDate = DateTime.Now, Position = "SomePos", Company = company2 },
                      new EmployeeDto() { FirstName = "SomeFirst0", LastName = "SomeLast", BirthDate = DateTime.Now, Position = "SomePos", Company = company2 }
                 );
                Histories.AddRange
                 (
                     new HistoryDto() { OrderDate = DateTime.Now, StoreCity = "SomeCity", Company = company1 },
                     new HistoryDto() { OrderDate = DateTime.Now, StoreCity = "SomeCity", Company = company1 },
                     new HistoryDto() { OrderDate = DateTime.Now, StoreCity = "SomeCity", Company = company1 },
                     new HistoryDto() { OrderDate = DateTime.Now, StoreCity = "SomeCity", Company = company1 },
                     new HistoryDto() { OrderDate = DateTime.Now, StoreCity = "SomeCity", Company = company2 },
                     new HistoryDto() { OrderDate = DateTime.Now, StoreCity = "SomeCity", Company = company2 },
                     new HistoryDto() { OrderDate = DateTime.Now, StoreCity = "SomeCity", Company = company2 },
                     new HistoryDto() { OrderDate = DateTime.Now, StoreCity = "SomeCity", Company = company2 },
                     new HistoryDto() { OrderDate = DateTime.Now, StoreCity = "SomeCity", Company = company2 }
                 );
                Notes.AddRange
                 (
                     new NoteDto() { InvoiceNumber = 123132, Employee = "SomeChel", Company = company1 },
                     new NoteDto() { InvoiceNumber = 123132, Employee = "SomeChel", Company = company1 },
                     new NoteDto() { InvoiceNumber = 123132, Employee = "SomeChel", Company = company1 },
                     new NoteDto() { InvoiceNumber = 123132, Employee = "SomeChel", Company = company1 },
                     new NoteDto() { InvoiceNumber = 123132, Employee = "SomeChel", Company = company2 },
                     new NoteDto() { InvoiceNumber = 123132, Employee = "SomeChel", Company = company2 },
                     new NoteDto() { InvoiceNumber = 123132, Employee = "SomeChel", Company = company2 },
                     new NoteDto() { InvoiceNumber = 123132, Employee = "SomeChel", Company = company2 },
                     new NoteDto() { InvoiceNumber = 123132, Employee = "SomeChel", Company = company2 },
                     new NoteDto() { InvoiceNumber = 123132, Employee = "SomeChel", Company = company2 },
                     new NoteDto() { InvoiceNumber = 123132, Employee = "SomeChel", Company = company1 },
                     new NoteDto() { InvoiceNumber = 123132, Employee = "SomeChel", Company = company1 },
                     new NoteDto() { InvoiceNumber = 123132, Employee = "SomeChel", Company = company1 },
                     new NoteDto() { InvoiceNumber = 123132, Employee = "SomeChel", Company = company1 }
                 );
                SaveChanges();
            }
        }
    }
}
