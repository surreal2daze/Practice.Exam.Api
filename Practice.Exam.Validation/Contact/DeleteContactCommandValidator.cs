using FluentValidation;
using Practice.Api.Declarations.Queryable;
using Practice.Exam.Shared.Model.Contact.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Exam.Validation.Contact
{
    public class DeleteContactCommandValidator : AbstractValidator<DeleteContactCommand>
    {
        public DeleteContactCommandValidator(
            IEntitySet<Practice.Api.Database.Contact.Contact> contacts)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x)
                .Must(x => contacts.Query().Any(s => s.Id == x.Id))
                .WithMessage("Id not found");

        }
    }
}