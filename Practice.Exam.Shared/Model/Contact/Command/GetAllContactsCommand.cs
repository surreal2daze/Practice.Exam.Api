using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Exam.Shared.Model.Contact.Command
{
    public class GetAllContactsCommand : IRequest<CommandResult<List<Contact>>>
    {
    }
}