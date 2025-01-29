
using PracticeCSharp.JsonSerializationAndDeserialization;
using PracticeCSharp.JsonSerializationAndDeserialization.MockData;
using PracticeCSharp.JsonSerializationAndDeserialization.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

//var empList = EmpAddMock.GetEmployees();

//var options = new JsonSerializerOptions
//{
//    WriteIndented = true,
//    //PropertyNamingPolicy = new CustomNamingPolicy(),
//    // Converters = { new JsonStringEnumConverter(JsonNamingPolicy.KebabCaseUpper) },
//};
//var employees = JsonSerializer.Serialize(empList, options);
////var employees = JsonSerializer.Serialize(empList, new JsonSerializerOptions { WriteIndented = true });

//var projectDirectory = @"C:\Users\sudha\OneDrive\Documents\GitHub\CSharpPractice\PracticeCSharp\JsonSerializationAndDeserialization";

//var filepath = Path.Combine(projectDirectory, "emp.json");
//File.WriteAllText(filepath, employees);
//Console.WriteLine("here is the empolyees in json format : {0}", employees);
var json = File.ReadAllText("emp.json");

var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
};
var des = JsonSerializer.Deserialize<List<Employee>>(json);

foreach(var item in des)
{
    Console.WriteLine(item.EmployeeSalary);
}