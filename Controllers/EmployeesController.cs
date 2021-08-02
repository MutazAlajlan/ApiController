using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIController.Data;
using APIController.Models;
using Microsoft.AspNetCore.Mvc;
namespace APIController.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _db;
        public EmployeesController(AppDbContext db)
        {
            _db = db;
        }
        //get /api/empoyees
        [HttpGet]
        public IActionResult Index()
        {
            var employees = _db.Employees.ToList();
            return Ok(employees);
        }

        //get /api/empoyees/2
        [HttpGet("{id}")]
        public IActionResult Details(int? id)
        {
            var employees = _db.Employees.ToList().Find(e => e.Id == id);
            if (id == null || employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }
        //post ~/api/employees
        [HttpPost]
        public IActionResult Create([FromBody] EmployeeModel emp)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(emp);
                _db.SaveChanges();
                return Ok(emp);
            }
            else
            {
                return NotFound();
            }
        }
        // Put /api/employees/3
        [HttpPut("{id}")]
        public IActionResult Edit(int? id, [FromBody] EmployeeModel emp)
        {
            if (id == null)
            {
                return NotFound();
            }
            emp.Id = (int)id;
            _db.Employees.Update(emp);
            _db.SaveChanges();

            return Ok(emp);
        }
        //Delete /api/employees/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            var employee = _db.Employees.ToList().FirstOrDefault(e => e.Id == id);
            if (id == null || employee == null)
            {
                return NotFound();
            }
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return Ok(employee);
        }
    }
}
