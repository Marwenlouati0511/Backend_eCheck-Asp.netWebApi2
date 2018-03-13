using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSampleProject.database;
using WebApiSampleProject.Models;
namespace WebApiSampleProject.Controllers
{
    public class EmployeController : ApiController
    {
        DB Db;
        public EmployeController()
        {
            Db = new DB();

        }

        public List<Employee> DataTableToModel(DataTable data)
        {
            List<Employee> List = new List<Employee>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Employee Employee = new Employee();

                Employee.EmployeeId = int.Parse(data.Rows[i][0].ToString());
                Employee.EmployeeName = data.Rows[i][1].ToString();
                Employee.Address = data.Rows[i][2].ToString();
                Employee.Department = data.Rows[i][3].ToString();

                List.Add(Employee);
            }
            return List;
        }

        [Route("api/Employees/read")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            DataTable ListEmployee = Db.executerSelect("select * from employee");
            List<Employee> list = DataTableToModel(ListEmployee);
            return Ok(list);
        }

        [Route("api/Employees/insert")]
        [HttpPost]
        public IHttpActionResult insertEmployee(Employee employee)
        {
            bool insertemployee = Db.executeCUD("INSERT INTO  employee (`EmployeeName`, `Address`, `Department`) values ('" + employee.EmployeeName + "', '" + employee.Address + "', '" + employee.Department + "')");
            if (insertemployee)
            {
                return Ok(200);
            }
            else
                return Ok(insertemployee);
        }


        [Route("api/Employees/remove")]
        [HttpDelete]
        public IHttpActionResult removeEmployee(Employee employee)
        {

            bool removeemployee = Db.executeCUD("DELETE FROM employee WHERE `EmployeeName` ='" + employee.EmployeeName + "' or `Address` ='" + employee.Address + "' or `Department` ='" + employee.Department + "'");
            if (removeemployee)
            {
                return Ok(200);
            }
            else
                return Ok(removeemployee);
        }
        [Route("api/Employees/update")]
        [HttpPut]
        public IHttpActionResult updateEmployee(Employee employee)
        {

            bool updateemployee = Db.executeCUD("UPDATE `employee` SET `EmployeeName`='" + employee.EmployeeName +"',`Address`='"+employee.Address+"',`Department`='"+employee.Department+"'  WHERE `EmployeeName`= '" + employee.EmployeeName + "'");
            if (updateemployee)
            {
                return Ok(200);
            }
            else
                return Ok(updateemployee);
        }
    }


}
