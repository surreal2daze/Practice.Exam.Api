using MediatR;
using Practice.Exam.Shared.Model.Contact.Command;
using Practice.Exam.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Api.Implementations.Queryable;
using Practice.Exam.Shared.Model;
using Practice.Api.Declarations.Queryable;
using Practice.Api.Declarations;

namespace Practice.Exam.Services.Implementation.Contact
{
    internal class CreateContactHandler : IRequestHandler<CreateContactCommand,
        CommandResult<ActionExecutionResult>>
    {
        public IEntitySet<Practice.Api.Database.Contact.Contact> _contact { get; set; }
        private readonly IUnitOfWorkService _unitOfWorkService;
        public CreateContactHandler(IEntitySet<Practice.Api.Database.Contact.Contact>  contact,
            IUnitOfWorkService unitOfWorkService)
        {
            _contact = contact;
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<CommandResult<ActionExecutionResult>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var model = new Practice.Api.Database.Contact.Contact();
            model.email =  request.email;
            model.address = new Practice.Api.Database.Contact.Address { 
                city = request.address.city,
                state = request.address.state,
                street = request.address.street,
                zip = request.address.zip
            };
            model.phone = request.phone.Select(s => new Api.Database.Contact.Phone { 
                number = s.number,
                type= s.type }).ToList();
            model.name = new Practice.Api.Database.Contact.Name 
            { 
                first = request.name.first,
                last = request.name.last,
                middle  = request.name.middle
            };
            
            _contact.Add(model);
            await _unitOfWorkService.SaveChangesAsync();
            return CommandResult<ActionExecutionResult>.Success(new ActionExecutionResult
            {
                Successful = true
            });
        }
    }
}
