using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSampleProject.Models;
namespace WebApiSampleProject.Controllers
{
    [RoutePrefix("api/Employees")]
    public class EmployeeController : ApiController
    {
        IList<Employee> employees = new List<Employee>()
        {
                new Employee()
                {
                    EmployeeId = 1, EmployeeName = "Mukesh Kumar", Address = "New Delhi", Department = "IT"
                },
                new Employee()
                {
                    EmployeeId = 6, EmployeeName = "makram", Address = "New Delhi", Department = "IT"
                },
                new Employee()
                {
                    EmployeeId = 2, EmployeeName = "makram", Address = "London", Department = "HR"
                },
                new Employee()
                {
                    EmployeeId = 3, EmployeeName = "Rahul Rathor", Address = "Laxmi Nagar", Department = "IT"
                },
                new Employee()
                {
                    EmployeeId = 4, EmployeeName = "YaduVeer Singh", Address = "Goa", Department = "Sales"
                },
                new Employee()
                {
                    EmployeeId = 5, EmployeeName = "Manish Sharma", Address = "New Delhi", Department = "HR"
                },
        };
        public IList<Employee> Employees { get => employees; set => employees = value; }
        [Route("reademployee")]
        [HttpGet]
        //[ActionName("reademployee")]
        public IList<Employee> ReadAllEmployees()
        {
            //Return list of all employees  
            return Employees;
        }
        [Route("createemployee")]
        [HttpPost]
        //[ActionName("createemployee")]

        //[Route("")]
        public IList<Employee> CreateAllEmployees()
        {
            //Return list of all employees  
            return Employees;
        }
        [Route("updateemployee")]
        [HttpPut]
        //[ActionName("updateemployee")]
        //[Route("")]
        public IList<Employee> UpdateAllEmployees()
        {
            //Return list of all employees  
            return Employees;
        }
        [Route("removeemployee")]
        [HttpDelete]
        //[ActionName("removeemployee")]

        //[Route("")]
        public IList<Employee> RemoveAllEmployees()
        {
            //Return list of all employees  
            return Employees;
        }
        //[Route("{name}")]
        /* public IList<Employee> GetEmployeeName (string name) {
             return Employees.Where(e => e.EmployeeName == name).ToList();  
         }
         [HttpGet]
         [ActionName("getEmp")]
         public Employee GetEmployeeDetails(int id)
         {
             //Return a single employee detail  
             var employee = Employees.FirstOrDefault(e => e.EmployeeId == id);
             if (employee == null)
             {
                 throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
             }
             return employee;
         }*/

        //[Route("{id:int}")]
        [Route("{reademployee}/{id:int}")]
        [HttpGet]
        //[ActionName("reademployee")]
        public Employee readEmployeeDetails(int id)
        {
            //Return a single employee detail  
            var employee = Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return employee;
        }
        [Route("{createemployee}/{id:int}")]
        [HttpPost]
        //[ActionName("createemployee")]
        public Employee createEmployeeDetails(int id)
        {
            //Return a single employee detail  
            var employee = Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return employee;
        }
        [Route("{updateemployee}/{id:int}")]
        [HttpPut]
        //[ActionName("updateemployee")]
        public Employee updateEmployeeDetails(int id)
        {
            //Return a single employee detail  
            var employee = Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return employee;
        }
        [Route("{removeemployee}/{id:int}")]
        [HttpDelete]
        //[ActionName("removeemployee")]
        public Employee removeEmployeeDetails(int id)
        {
            //Return a single employee detail  
            var employee = Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return employee;
        }
    }
}