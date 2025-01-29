
using PracticeCSharp.JsonSerializationAndDeserialization;
using PracticeCSharp.JsonSerializationAndDeserialization.MockData;
    using System.Text.Json;

    var empList = EmpAddMock.GetEmployees();

var options  = new JsonSerializerOptions { WriteIndented = true ,PropertyNamingPolicy=new CustomNamingPolicy()};
    var employees = JsonSerializer.Serialize(empList,options);
   // var employees = JsonSerializer.Serialize(empList,new JsonSerializerOptions { WriteIndented=true});

    var projectDirectory = @"C:\Users\sudha\OneDrive\Documents\GitHub\CSharpPractice\PracticeCSharp\JsonSerializationAndDeserialization";

    var filepath = Path.Combine(projectDirectory, "emp.json");
    File.WriteAllText(filepath, employees);
    Console.WriteLine("here is the empolyees in json format : {0}",employees );