using FluentValidation;
using Practice.Api.Declarations.Queryable;
using Practice.Exam.Shared.Model.Contact.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Exam.Validation.Contact
{
    public class CallListContactCommandValidator : AbstractValidator<CallListContactCommand>
    {
        public CallListContactCommandValidator()
        {

        }
    }
}
