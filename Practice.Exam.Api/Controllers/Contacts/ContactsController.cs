using MediatR;
using Microsoft.AspNetCore.Mvc;
using Practice.Exam.API.Common;
using Practice.Exam.Shared;
using Practice.Exam.Shared.Model;
using Practice.Exam.Shared.Model.Contact;
using Practice.Exam.Shared.Model.Contact.Command;
using System.Net;

namespace Practice.Exam.Api.Controllers.Contacts
{
    [Route(InternalConstants.DefaultControllerRoute)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.InternalServerError)]
    public class ContactsController : BaseController
    {
        public ContactsController(IMediator mediator) :base(mediator)
        {

        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Contact>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationResultModel), (int)HttpStatusCode.BadRequest)]
        public Task<IActionResult> AllContacts([FromQuery] GetAllContactsCommand request) =>
            SendAsync(request);

        [HttpPost]
        [ProducesResponseType(typeof(ActionExecutionResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationResultModel), (int)HttpStatusCode.BadRequest)]
        public Task<IActionResult> CreateContact([FromBody] CreateContactCommand request) =>
            SendAsync(request);

        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(ActionExecutionResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationResultModel), (int)HttpStatusCode.BadRequest)]
        public Task<IActionResult> UpdateContact(UpdateContactCommand request) =>
            SendAsync(request);

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(Contact), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationResultModel), (int)HttpStatusCode.BadRequest)]
        public Task<IActionResult> GetSpecificContact([FromRoute] GetSpecificContactCommand request) =>
            SendAsync(request);

        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(ActionExecutionResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationResultModel), (int)HttpStatusCode.BadRequest)]
        public Task<IActionResult> DeleteContact([FromRoute] DeleteContactCommand request) =>
            SendAsync(request);

        [HttpGet("call-list")]
        [ProducesResponseType(typeof(List<Contact>), (int)HttpStatusCode.OK)]
        public Task<IActionResult> CallList([FromQuery] CallListContactCommand request) =>
            SendAsync(request);
    }
}