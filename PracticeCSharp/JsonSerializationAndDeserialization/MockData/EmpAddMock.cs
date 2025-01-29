using PracticeCSharp.JsonSerializationAndDeserialization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PracticeCSharp.JsonSerializationAndDeserialization.Enums;

namespace PracticeCSharp.JsonSerializationAndDeserialization.MockData
{
    public class EmpAddMock
    {

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>()
    {
        new Employee
        {
            EmployeeId = 1,
            EmployeeName = "Sudhar",
            EmployeeSalary = "1000",
            Deparments=Departments.IT,
            Address = new Address
            {
                EmployeeStreet = "1, Main Road",
                EmployeeDistrict = "Villupuram",
                EmployeeState = "Tamil Nadu",
                EmployeePinCode = "604304"
            }
        },
        new Employee
        {
            EmployeeId = 2,
            EmployeeName = "Ravi",
            EmployeeSalary = "2000",
            Deparments= Departments.HR,
            Address = new Address
            {
                EmployeeStreet = "12, Gandhi Street",
                EmployeeDistrict = "Chennai",
                EmployeeState = "Tamil Nadu",
                EmployeePinCode = "600001"
            }
        },
        new Employee
        {
            EmployeeId = 3,
            EmployeeName = "Priya",
            EmployeeSalary = "1500",
            Deparments= Departments.HR,
            Address = new Address
            {
                EmployeeStreet = "45, Anna Nagar",
                EmployeeDistrict = "Coimbatore",
                EmployeeState = "Tamil Nadu",
                EmployeePinCode = "641001"
            }
        },
        new Employee
        {
            EmployeeId = 4,
            EmployeeName = "Karthik",
            EmployeeSalary = "2500",
            Deparments= Departments.Finance,
            Address = new Address
            {
                EmployeeStreet = "23, MG Road",
                EmployeeDistrict = "Madurai",
                EmployeeState = "Tamil Nadu",
                EmployeePinCode = "625002"
            }
        },
        new Employee
        {
            EmployeeId = 5,
            EmployeeName = "Anitha",
            EmployeeSalary = "1800",
            Deparments= Departments.Admin,
            Address = new Address
            {
                EmployeeStreet = "78, Poonamallee High Road",
                EmployeeDistrict = "Trichy",
                EmployeeState = "Tamil Nadu",
                EmployeePinCode = "620008"
            }
        }
    };

            return employees;
        }

    }
}
