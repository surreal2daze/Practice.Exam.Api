using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Exam.Shared.Model.Contact
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Name
    {
        public string first { get; set; }
        public string middle { get; set; }
        public string last { get; set; }
    }
}