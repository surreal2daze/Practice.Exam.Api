using MediatR;
using Practice.Exam.Shared.Model.Contact.Command;
using Practice.Exam.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Api.Declarations.Queryable;
using Microsoft.EntityFrameworkCore;

namespace Practice.Exam.Services.Implementation.Contact
{
    internal class GetSpecificContactHandler : IRequestHandler<GetSpecificContactCommand,
        CommandResult<Practice.Exam.Shared.Model.Contact.Contact>>
    {
        public IEntitySet<Practice.Api.Database.Contact.Contact> _contact { get; set; }
        public GetSpecificContactHandler(IEntitySet<Practice.Api.Database.Contact.Contact> contact)
        {
            _contact = contact;
        }
        public async Task<CommandResult<Shared.Model.Contact.Contact>> Handle(GetSpecificContactCommand request, CancellationToken cancellationToken)
        {
            var entity = _contact.Query().Include("phone").SingleOrDefault(s => s.Id == request.Id);

            var entityModel = new Shared.Model.Contact.Contact { 
                Id = entity.Id,
                address = new Shared.Model.Contact.Address { 
                    city = entity.address.city,
                    state = entity.address.state,
                    street = entity.address.street,
                    zip = entity.address.zip,
                },
                email = entity.email,
                name = new Shared.Model.Contact.Name { 
                    first = entity.name.first,
                    last = entity.name.last,
                    middle = entity.name.middle,
                },
                phone = entity.phone.Select(s => new Shared.Model.Contact.Phone{ 
                    number = s.number,
                    type = s.type
                }).ToList()
            };


          return CommandResult<Practice.Exam.Shared.Model.Contact.Contact>
                .Success(entityModel);
        }
    }
}
