using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Exam.Shared.Model.Contact.Command
{
    public class CreateContactCommand : IRequest<CommandResult<ActionExecutionResult>>
    {
        public int Id { get; set; }
        public Name name { get; set; }
        public Address address { get; set; }
        public List<Phone> phone { get; set; }
        public string email { get; set; }
    }
}