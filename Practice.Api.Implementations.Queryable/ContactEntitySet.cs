using Practice.Api.Database;
using Practice.Api.Database.Contact;

namespace Practice.Api.Implementations.Queryable
{
    public class ContactEntitySet : EntitySet<Contact>
    {
        public ContactEntitySet(PracticeApiContext context) : base(context)
        {

        }
    }
}