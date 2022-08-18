using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Api.Database.Contact
{
    [ComplexType]
    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
    }

    //public class AddressBuilder : IEntityTypeConfiguration<Address>
    //{
    //    public void Configure(EntityTypeBuilder<Address> builder)
    //    {
    //        builder
    //            .Property(x => x.street)
    //            .HasColumnName("first")
    //            .IsRequired()
    //            .HasColumnType("nvarchar(50)");

    //        builder
    //            .Property(x => x.city)
    //            .HasColumnName("middle")
    //            .IsRequired()
    //            .HasColumnType("nvarchar(50)");

    //        builder
    //            .Property(x => x.state)
    //            .HasColumnName("last")
    //            .IsRequired()
    //            .HasColumnType("nvarchar(50)");

    //        builder
    //            .Property(x => x.zip)
    //            .HasColumnName("last")
    //            .IsRequired()
    //            .HasColumnType("nvarchar(50)");
    //    }
    //}
}