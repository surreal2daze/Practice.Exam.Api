using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Practice.Exam.Shared.Model.Contact.Command
{
    public class UpdateContactCommand: IRequest<CommandResult<ActionExecutionResult>>
    {
        [FromRoute]
        public int Id { get; set; }
        
        [FromBody]
        
        public Contact contact { get; set; }
    }
}