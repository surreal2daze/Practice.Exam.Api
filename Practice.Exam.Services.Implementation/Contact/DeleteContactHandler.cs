using MediatR;
using Practice.Exam.Shared.Model.Contact.Command;
using Practice.Exam.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Api.Declarations.Queryable;
using Practice.Api.Declarations;
using Practice.Exam.Shared.Model;

namespace Practice.Exam.Services.Implementation.Contact
{
    internal class DeleteContactHandler : IRequestHandler<DeleteContactCommand,
        CommandResult<ActionExecutionResult>>
    {
        public IEntitySet<Practice.Api.Database.Contact.Contact> _contact { get; set; }
        private readonly IUnitOfWorkService _unitOfWorkService;
        public DeleteContactHandler(IEntitySet<Practice.Api.Database.Contact.Contact> contact,
            IUnitOfWorkService unitOfWorkService)
        {
            _contact = contact;
            _unitOfWorkService = unitOfWorkService;
        }
        public async Task<CommandResult<ActionExecutionResult>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var entity = _contact.Query().Where(s => s.Id == request.Id).FirstOrDefault();

            _contact.Remove(entity);
            await _unitOfWorkService.SaveChangesAsync();
            return CommandResult<ActionExecutionResult>.Success(new ActionExecutionResult
            {
                Successful = true
            });
        }
    }
}
