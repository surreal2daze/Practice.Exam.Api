using MediatR;
using Practice.Exam.Shared.Model.Contact.Command;
using Practice.Exam.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Exam.Shared.Model;
using Practice.Api.Declarations.Queryable;
using Practice.Api.Declarations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Practice.Exam.Services.Implementation.Contact
{
    internal class UpdateContactHandler : IRequestHandler<UpdateContactCommand,
        CommandResult<ActionExecutionResult>>
    {
        public IEntitySet<Practice.Api.Database.Contact.Contact> _contact { get; set; }
        private readonly IUnitOfWorkService _unitOfWorkService;
        public UpdateContactHandler(IEntitySet<Practice.Api.Database.Contact.Contact> contact,
            IUnitOfWorkService unitOfWorkService)
        {
            _contact = contact;
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<CommandResult<ActionExecutionResult>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var entity = _contact.Query().Include("phone").Where(s => s.Id == request.Id).FirstOrDefault();

            foreach (var item in request.contact.phone)
            {
                var phone = entity.phone.Where( s => s.type == item.type || s.number == item.number).FirstOrDefault();
                if (phone != null)
                {
                    phone.number = item.number;
                    phone.type = item.type;

                    entity.phone.Add(phone);
                }
            }

            entity.email = request.contact.email;
            entity.address.state = request.contact.address.state;
            entity.address.state = request.contact.address.state;
            entity.address.state = request.contact.address.state;
            entity.address.state = request.contact.address.state;

            entity.name.first = request.contact.name.first;
            entity.name.middle = request.contact.name.middle;
            entity.name.last = request.contact.name.middle;

            _contact.Attach(entity);
            _contact.Entry(entity).State = EntityState.Modified;

            await _unitOfWorkService.SaveChangesAsync();
            return CommandResult<ActionExecutionResult>.Success(new ActionExecutionResult
            {
                Successful = true
            });
        }
    }
}
