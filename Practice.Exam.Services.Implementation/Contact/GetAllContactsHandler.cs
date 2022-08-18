using MediatR;
using Practice.Exam.Shared.Model.Contact.Command;
using Practice.Exam.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Api.Declarations.Queryable;

namespace Practice.Exam.Services.Implementation.Contact
{
    internal class GetAllContactsHandler : IRequestHandler<GetAllContactsCommand,
        CommandResult<List<Practice.Exam.Shared.Model.Contact.Contact>>>
    {
        public IEntitySet<Practice.Api.Database.Contact.Contact> _contact { get; set; }

        public GetAllContactsHandler(IEntitySet<Practice.Api.Database.Contact.Contact> contact)
        {
            _contact = contact;
        }

        public async Task<CommandResult<List<Shared.Model.Contact.Contact>>> Handle(GetAllContactsCommand request, CancellationToken cancellationToken)
        {
            var contacts = _contact.Query().Select(s => new Practice.Exam.Shared.Model.Contact.Contact
            {
                address = new Shared.Model.Contact.Address
                {
                    city = s.address.city,
                    state = s.address.state,
                    street = s.address.street,
                    zip = s.address.zip
                },
                email = s.email,
                Id = s.Id,
                name = new Shared.Model.Contact.Name
                {
                    first = s.name.first,
                    last = s.name.last,
                    middle = s.name.middle
                },
                phone = s.phone.Select(s => new Shared.Model.Contact.Phone { number = s.number, type = s.type }).ToList()
            }).ToList();

            return CommandResult<List<Practice.Exam.Shared.Model.Contact.Contact>>
                .Success(contacts.ToList());
        }
    }
}