using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TestovoeBack.Models;
using static Azure.Core.HttpHeader;

namespace TestovoeBack.Controllers
{
    [ApiController]
    [Route("api")]
    public class TestovoeController : ControllerBase
    {
        private readonly ApplicationContext db;
        public TestovoeController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet("testovoe/companies")]
        public ActionResult<List<CompanyDto>> GetCompanies()
        {
            return Ok(db.Companies.Include(c => c.Employees).Include(c => c.Notes).Include(c => c.Histories).ToList());
        }
        [HttpPost("testovoe/companies")]
        public ActionResult<string> CreateCompany(CompanyDto companyDto)
        {
            CompanyDto company = new CompanyDto()
            {
                Name = companyDto.Name,
                Adress = companyDto.Adress,
                City = companyDto.City,
                Phone = companyDto.Phone,
                State = companyDto.State,
            };
            db.Companies.Add(company);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException err)
            {
                return BadRequest(err.Message);
            }
            catch (DbUpdateException err)
            {
                return BadRequest(err.Message);
            }
            return Ok();
        }
        [HttpPut("testovoe/companies")]
        public ActionResult<string> UpdateCompany(CompanyDto companyDto)
        {
            CompanyDto? company = db.Companies.FirstOrDefault(c => c.Id == companyDto.Id);
            if (company == null)
                return BadRequest();
            company.Name = companyDto.Name;
            company.Adress = companyDto.Adress;
            company.City = companyDto.City;
            company.Phone = companyDto.Phone;
            company.State = companyDto.State;
            db.Companies.Update(company);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException err)
            {
                return BadRequest(err.Message);
            }
            catch (DbUpdateException err)
            {
                return BadRequest(err.Message);
            }
            return Ok();
        }
        [HttpPost("testovoe/employees")]
        public ActionResult<string> CreateEmployee(EmployeeDto employeeDto)
        {
            CompanyDto? company = db.Companies.FirstOrDefault(c => c.Id == employeeDto.CompanyId);
            if (company == null)
                return BadRequest();
            EmployeeDto employee = new EmployeeDto()
            {
                Company = company,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                BirthDate = employeeDto.BirthDate,
                Position = employeeDto.Position,
                Title = employeeDto.Title,
            };
            db.Employees.Add(employee);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException err)
            {
                return BadRequest(err.Message);
            }
            catch (DbUpdateException err)
            {
                return BadRequest(err.Message);
            }
            return Ok();
        }
        [HttpPut("testovoe/employees")]
        public ActionResult<string> UpdateEmployee(EmployeeDto employeeDto)
        {
            EmployeeDto? employee = db.Employees.FirstOrDefault(c => c.Id == employeeDto.Id);
            if (employee == null)
                return BadRequest();
            employee.FirstName = employeeDto.FirstName;
            employee.LastName = employeeDto.LastName;
            employee.BirthDate = employeeDto.BirthDate;
            employee.Position = employeeDto.Position;
            employee.Title = employeeDto.Title;
            db.Employees.Update(employee);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException err)
            {
                return BadRequest(err.Message);
            }
            catch (DbUpdateException err)
            {
                return BadRequest(err.Message);
            }
            return Ok();
        }
        [HttpPatch("testovoe/employees")]
        public ActionResult<string> DeleteEmployee(EmployeeDto employeeDto)
        {
            EmployeeDto? employee = db.Employees.FirstOrDefault(c => c.Id == employeeDto.Id);
            if (employee == null)
                return BadRequest();
            db.Employees.Remove(employee);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException err)
            {
                return BadRequest(err.Message);
            }
            catch (DbUpdateException err)
            {
                return BadRequest(err.Message);
            }
            return Ok();
        }
        [HttpPost("testovoe/notes")]
        public ActionResult<string> CreateNote(NoteDto noteDto)
        {
            CompanyDto? company = db.Companies.FirstOrDefault(c => c.Id == noteDto.CompanyId);
            if (company == null)
                return BadRequest();
            NoteDto note = new NoteDto()
            {
                Company = company,
                Employee = noteDto.Employee,
                InvoiceNumber = noteDto.InvoiceNumber,
            };
            db.Notes.Add(note);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException err)
            {
                return BadRequest(err.Message);
            }
            catch (DbUpdateException err)
            {
                return BadRequest(err.Message);
            }
            return Ok();
        }
        [HttpPatch("testovoe/notes")]
        public ActionResult<string> DeleteNote(NoteDto noteDto)
        {
            NoteDto? note = db.Notes.FirstOrDefault(c => c.Id == noteDto.Id);
            if (note == null)
                return BadRequest();
            db.Notes.Remove(note);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException err)
            {
                return BadRequest(err.Message);
            }
            catch (DbUpdateException err)
            {
                return BadRequest(err.Message);
            }
            return Ok();
        }
    }
}
