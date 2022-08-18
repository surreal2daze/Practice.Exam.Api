using FluentValidation;
using Practice.Exam.Shared.Model.Contact.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Exam.Validation.Contact
{
    public class CreateContactCommandValidator: AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {

        }
    }
}
