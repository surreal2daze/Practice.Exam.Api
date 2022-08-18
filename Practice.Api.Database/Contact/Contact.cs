using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Practice.Api.Database.Contact
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public Name name { get; set; }
        public Address address { get; set; }
        public List<Phone> phone { get; set; }
        public string email { get; set; }
    }

    public class ContactBuilder : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder
                .ToTable("Contact")
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("contactId");

            builder
                .Property(x => x.email)
                .HasColumnName("email")
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.OwnsOne<Address>("address")
                .Property(s => s.street);
            builder.OwnsOne<Address>("address")
                .Property(s => s.city);
            builder.OwnsOne<Address>("address")
                .Property(s => s.state);
            builder.OwnsOne<Address>("address")
                .Property(s => s.zip);

            builder.OwnsOne<Name>("name")
                .Property(s => s.first)
                .HasMaxLength(42);

            builder.OwnsOne<Name>("name")
                .Property(s => s.last)
                .HasMaxLength(42);

            builder.OwnsOne<Name>("name")
                .Property(s => s.last)
                .HasMaxLength(42);
        }
    }
}