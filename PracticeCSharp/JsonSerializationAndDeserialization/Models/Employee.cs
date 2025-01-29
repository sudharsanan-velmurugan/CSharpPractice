using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PracticeCSharp.JsonSerializationAndDeserialization.Enums;

namespace PracticeCSharp.JsonSerializationAndDeserialization.Models
{
    public class Employee
    {
        //[JsonInclude]
        //public string NickName = "Vegeta";
        [JsonIgnore]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSalary { get; set; }

        [JsonPropertyName("Address Details")]
        public Address Address { get; set; }

        public Departments Deparments { get; set; }
    }
}
