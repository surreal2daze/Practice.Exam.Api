using Practice.Api.Database;
using Practice.Api.Database.Contact;

namespace Practice.Api.Implementations.Queryable
{
    public class PhoneEntitySet : EntitySet<Phone>
    {
        public PhoneEntitySet(PracticeApiContext context) : base(context)
        {
        }
    }
}