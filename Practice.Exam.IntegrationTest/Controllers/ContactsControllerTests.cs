using Newtonsoft.Json;
using Practice.Exam.Shared;
using Practice.Exam.Shared.Model.Contact.Command;
using Shouldly;
using Practice.Exam.Shared.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Exam.Shared.Model.Contact;
using Practice.Api.Database.Contact;
using Contact = Practice.Exam.Shared.Model.Contact.Contact;
using Name = Practice.Exam.Shared.Model.Contact.Name;
using Address = Practice.Exam.Shared.Model.Contact.Address;
using Phone = Practice.Exam.Shared.Model.Contact.Phone;
using Practice.Exam.Shared.Model;

namespace Practice.Exam.IntegrationTest.Controllers
{
    public class ContactsControllerTests : ControllerBaseTest
    {
        public override void Init()
        {
            base.Init();
        }

        [Test]
        public async Task Should_Passed_GetAllContacts()
        {
            // Arrange
            var contact = new Contact { };

            var request = new CreateContactCommand
            {
                email = "sample@email.com",
                name = new Name { first = "sampleFirst", middle = "sampleMiddle", last = "sampleLast" },
                address = new Address { city = "sampleCity", state = "sampleState", street = "sampleStreet", zip = 21234 },
                phone = new List<Phone>() { new Phone { number = "123-213-123", type = "Work" } }

            };

            var contact1 = new Contact { };
            var result = await CreateContactAsync<ValidationResultModel>(request);

            var request1 = new CreateContactCommand
            {
                email = "sample@email.com",
                name = new Name { first = "sampleFirst", middle = "sampleMiddle", last = "sampleLast" },
                address = new Address { city = "sampleCity", state = "sampleState", street = "sampleStreet", zip = 21234 },
                phone = new List<Phone>() { new Phone { number = "123-213-123", type = "Work" } }

            };
            var result1 = await CreateContactAsync<ValidationResultModel>(request1);

            // Action

            var resultd = await GetCallListAsync<List<Contact>>(
                new CallListContactCommand { });


            // Assert
            result.ErrorMessage.ShouldBeNull(Resources.Validation_Failed);
            resultd.Count.ShouldBe(2);
        }

        [Test]
        public async Task Should_Passed_CreateContact()
        {
            // Arrange
            var contact = new Contact { };

            var request = new CreateContactCommand
            {
                email = "sample@email.com",
                name = new Name { first = "sampleFirst", middle = "sampleMiddle", last = "sampleLast" },
                address = new Address { city = "sampleCity", state = "sampleState", street = "sampleStreet", zip = 21234},
                phone = new List<Phone>() { new Phone {number = "123-213-123", type="Work" }}
               
            };
            

            // Action
            var result = await CreateContactAsync<ValidationResultModel>(request);
            var resultd = await GetCallListAsync<List<Contact>>(
                new CallListContactCommand { });

            // Assert
            result.ErrorMessage.ShouldBeNull(Resources.Validation_Failed);
            resultd.Count.ShouldBe(1);
        }

        [Test]
        public async Task Should_Passed_UpdateContact()
        {
            // Arrange
            var contact = new Contact { };

            var add = new CreateContactCommand
            {
                email = "sample@email.com",
                name = new Name { first = "sampleFirst", middle = "sampleMiddle", last = "sampleLast" },
                address = new Address { city = "sampleCity", state = "sampleState", street = "sampleStreet", zip = 21234 },
                phone = new List<Phone>() { new Phone { number = "123-213-123", type = "Work" } }

            };

            // Action
            var resultAdd = await CreateContactAsync<ValidationResultModel>(add);

            var entity = new Contact
            {
                email = "Change@email.com",
                name = new Name { first = "sampleFirst", middle = "sampleMiddle", last = "sampleLast" },
                address = new Address { city = "sampleCity", state = "sampleState", street = "sampleStreet", zip = 21234 },
                phone = new List<Phone>() { new Phone { number = "123-213-123", type = "Work" } }
            };
            var request = new UpdateContactCommand
            {
                Id = 1,
                contact = entity
            };

            // Action
            var result = await UpdateContactAsync<ActionExecutionResult>(request.Id,request);

            // Assert
        }

        [Test]
        public async Task Should_Passed_DeleteContact()
        {
            // Arrange
            var contact = new Contact { };

            var request = new CreateContactCommand
            {
                email = "sample@email.com",
                name = new Name { first = "sampleFirst", middle = "sampleMiddle", last = "sampleLast" },
                address = new Address { city = "sampleCity", state = "sampleState", street = "sampleStreet", zip = 21234 },
                phone = new List<Phone>() { new Phone { number = "123-213-123", type = "Work" } }

            };

            var contact1 = new Contact { };
            var result = await CreateContactAsync<ValidationResultModel>(request);

            var request1 = new CreateContactCommand
            {
                email = "sample@email.com",
                name = new Name { first = "sampleFirst", middle = "sampleMiddle", last = "sampleLast" },
                address = new Address { city = "sampleCity", state = "sampleState", street = "sampleStreet", zip = 21234 },
                phone = new List<Phone>() { new Phone { number = "123-213-123", type = "Work" } }

            };
            var result1 = await CreateContactAsync<ValidationResultModel>(request1);

            // Action

            var resultd = await DeleteContactAsync<ValidationResultModel>(1);


            var resultsd = await GetCallListAsync<List<Contact>>(
                new CallListContactCommand { });

            // Assert
            result.ErrorMessage.ShouldBeNull(Resources.Validation_Failed);
            resultsd.Count.ShouldBe(1);
        }


        private async Task<TResponse> GetAllContactsAsync<TResponse>(
             GetAllContactsCommand request)
        {
            var url = $"api/contacts";
            var response = await GetAsync(url);
            var s = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResponse>(s);
            return result;
        }

        private async Task<TResponse> GetCallListAsync<TResponse>(
             CallListContactCommand request)
        {
            var url = $"api/contacts/call-list";
            var response = await GetAsync(url);
            var s = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResponse>(s);
            return result;
        }

        private async Task<TResponse> CreateContactAsync<TResponse>(
             CreateContactCommand request)
        {
            var url = $"api/contacts";
            var response = await PostAsync(url, request);
            var s = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResponse>(s);
            return result;
        }

        private async Task<TResponse> UpdateContactAsync<TResponse>(
             int Id,UpdateContactCommand request)
        {
            var url = $"api/contacts/{Id}";
            var response = await PutAsync(url, request);
            var s = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResponse>(s);
            return result;
        }

        private async Task<TResponse> DeleteContactAsync<TResponse>(
             int Id)
        {
            var url = $"api/contacts/{Id}";
            var response = await DeleteAsync(url);
            var s = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResponse>(s);
            return result;
        }
    }
}