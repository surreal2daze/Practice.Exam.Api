using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Practice.Exam.Shared.Model.Contact;

namespace Practice.Api.Database.Contact
{
    public class Phone : IEntity
    {
        public int id { get; set; }
        public Contact contact { get; set; }
        public int contactId { get; set; }
        public string number { get; set; }
        public string type { get; set; }
        public PhoneType phoneType
        {
            get => (PhoneType)Enum.Parse(typeof(PhoneType), type);
            set => type = value.ToString();
        }
    }

    public class PhoneBuilder : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder
                .ToTable("Phone")
                .HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnName("phoneId");

            builder
                .Property(x => x.contactId)
                .IsRequired();

            builder
                .Property(x => x.number)
                .HasColumnName("number")
                .IsRequired()
                .HasColumnType("nvarchar(25)");

            builder
                .Property(x => x.type)
                .HasColumnName("type")
                .HasColumnType("nvarchar(15)")
                .IsRequired();

            builder.Ignore(x => x.phoneType);
        }
    }
}