using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Exam.Shared.Model.Contact
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Phone
    {
        public string number { get; set; }
        public string type { get; set; }
    }
}