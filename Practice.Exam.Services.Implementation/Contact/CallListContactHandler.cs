using MediatR;
using Practice.Api.Declarations.Queryable;
using Practice.Exam.Shared;
using Practice.Exam.Shared.Model.Contact.Command;

namespace Practice.Exam.Services.Implementation.Contact
{
    public class CallListContactHandler : IRequestHandler<CallListContactCommand,
        CommandResult<List<Practice.Exam.Shared.Model.Contact.CallList>>>
    {
        public IEntitySet<Practice.Api.Database.Contact.Contact> _contact { get; set; }
        public CallListContactHandler(IEntitySet<Practice.Api.Database.Contact.Contact> contact)
        {
            _contact = contact;
        }

        public async Task<CommandResult<List<Practice.Exam.Shared.Model.Contact.CallList>>> Handle(CallListContactCommand request, CancellationToken cancellationToken)
        {
            var contacts = _contact.Query().Select(s => new Practice.Exam.Shared.Model.Contact.CallList
            {
                name = new Shared.Model.Contact.Name {
                    first = s.name.first,
                    last = s.name.last,
                    middle = s.name.middle
                },
                phone = s.phone.FirstOrDefault().number
            }).OrderBy(s => s.name.first).ThenBy(s => s.name.last).ToList();

            //sorted last name and then by first name , return array of object
            return CommandResult<List<Practice.Exam.Shared.Model.Contact.CallList>>
                .Success(contacts);
        }
    }
}