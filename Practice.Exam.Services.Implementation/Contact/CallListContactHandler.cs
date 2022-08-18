using MediatR;
using Practice.Api.Declarations.Queryable;
using Practice.Exam.Shared;
using Practice.Exam.Shared.Model.Contact.Command;

namespace Practice.Exam.Services.Implementation.Contact
{
    public class CallListContactHandler : IRequestHandler<CallListContactCommand,
        CommandResult<List<Practice.Exam.Shared.Model.Contact.Contact>>>
    {
        public IEntitySet<Practice.Api.Database.Contact.Contact> _contact { get; set; }
        public CallListContactHandler(IEntitySet<Practice.Api.Database.Contact.Contact> contact)
        {
            _contact = contact;
        }

        public async Task<CommandResult<List<Practice.Exam.Shared.Model.Contact.Contact>>> Handle(CallListContactCommand request, CancellationToken cancellationToken)
        {
            var contacts = _contact.Query().Select(s => new Practice.Exam.Shared.Model.Contact.Contact
            {
                name = new Shared.Model.Contact.Name {
                    first = s.name.first,
                    last = s.name.last,
                    middle = s.name.middle
                },
                phone = s.phone.Select(s => new Shared.Model.Contact.Phone { number = s.number }).ToList()
            }).OrderBy(s => s.name.first).ThenBy(s => s.name.last).ToList();

            //sorted last name and then by first name , return array of object
            return CommandResult<List<Practice.Exam.Shared.Model.Contact.Contact>>
                .Success(contacts);
        }
    }
}