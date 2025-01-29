using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PracticeCSharp.JsonSerializationAndDeserialization
{
    public class CustomNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return "S " + name;
        }
    }
}
